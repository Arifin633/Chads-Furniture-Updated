using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Chests : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Chests";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/ChestsHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicChest[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Containers };
            for (int i = 0; i <= 3; i++)
            {
                AddMapEntry(new Color(174, 129, 92), this.GetLocalization("MapEntry" + i), MapChestName);
            }
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override LocalizedText DefaultContainerName(int frameX, int frameY)
            => this.GetLocalization("MapEntry" + (frameX / 36));

        public static string MapChestName(string name, int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % 2));
            int top = (tile.TileFrameY != 0) ? (j - 1) : j;

            int chest = Chest.FindChest(left, top);

            if (Main.chest[chest].name is "" or "Princess Chest"
                                             or "Mystical Chest"
                                             or "Royal Chest"
                                             or "Sandstone Urn")
                return name;

            return name + ": " + Main.chest[chest].name;
        }

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinChest>(),
              ModContent.ItemType<Items.MysticChest>(),
              ModContent.ItemType<Items.RoyalChest>(),
              ModContent.ItemType<Items.SandstoneChest>() };


        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 36)
            {
                case 0:
                case 2:
                    type = DustID.Gold;
                    break;
                case 1:
                    type = DustID.PurpleTorch;
                    break;
                case 3:
                    type = DustID.Sluggy;
                    break;
            }
            return true;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
            => Chest.DestroyChest(i, j);

        public override bool RightClick(int i, int j)
        {
            CFUtils.OpenChest(i, j, 2);
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;

            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % 2));
            int top = (tile.TileFrameY != 0) ? (j - 1) : j;

            int chest = Chest.FindChest(left, top);
            player.cursorItemIconText = Main.chest[chest].name;
            switch (tile.TileFrameX / 36)
            {
                case 0:
                    if (Main.chest[chest].name is "Princess Chest" or "")
                    {
                        player.cursorItemIconID = Styles[0];
                        player.cursorItemIconText = "";
                    }
                    break;
                case 1:
                    if (Main.chest[chest].name is "Mystical Chest" or "")
                    {
                        player.cursorItemIconID = Styles[1];
                        player.cursorItemIconText = "";
                    }
                    break;
                case 2:
                    if (Main.chest[chest].name is "Royal Chest" or "")
                    {
                        player.cursorItemIconID = Styles[2];
                        player.cursorItemIconText = "";
                    }
                    break;
                case 3:
                    if (Main.chest[chest].name is "Sandstone Urn" or "")
                    {
                        player.cursorItemIconID = Styles[3];
                        player.cursorItemIconText = "";
                    }
                    break;
            }
        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;
            if (frameX is 36 or 54)
            {
                int chest = Chest.FindChest((frameX == 54) ? (i - 1) : i,
                                            (frameY == 18) ? (j - 1) : j);
                if (Main.chest[chest].frame == 2)
                {
                    /* These values still aren't great. */
                    ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
                    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                    for (int k = 0; k < 2; k++)
                    {
                        float x = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.033f;
                        float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.05f;
                        spriteBatch.Draw(
                            ModContent.Request<Texture2D>("CFU/Textures/Tiles/Furniture/MysticChestVoid").Value,
                            new Vector2((float)(i * 16 - (int)Main.screenPosition.X) + x, (float)(j * 16 - (int)Main.screenPosition.Y) + y) + zero,
                            new Rectangle((frameX == 54) ? 18 : 0, (frameY == 18) ? 18 : 0, 16, 16),
                            Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
                    }
                }
            }
        }
    }
}
