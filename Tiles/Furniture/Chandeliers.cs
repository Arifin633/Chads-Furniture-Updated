using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Chandeliers : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Chandeliers";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.Origin = new Point16(1, 0);
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chandelier");
            AddMapEntry(new Color(181, 172, 190), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Torches };
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 54)
            {
                switch (Main.tile[i, j].TileFrameY / 18)
                {
                    case 1: /* Princess */
                        r = 0.7f;
                        g = 0.9f;
                        b = 1f;
                        break;
                    case 4: /* Mystic */
                        r = 0.7f;
                        g = 0.3f;
                        b = 0.7f;
                        break;
                    case 10: /* Sandstone */
                    case 11:
                        r = 1f;
                        g = 0.5f;
                        b = 0f;
                        break;
                }
            }
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 54)
                CFUtils.ShiftTileX(i, j, 3, 3, 54, false, true);
            else
                CFUtils.ShiftTileX(i, j, 3, 3, 54, true, true);
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            // if (Main.tile[i, j].TileFrameX < 54)
            // {
            //     CFUTileDraw.DrawFlame(i, j, spriteBatch);
            // }
            if (Main.tile[i, j].TileFrameY % 54 == 0 &&
                Main.tile[i, j].TileFrameX % 54 == 0)
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingTile);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinChandelier>(),
                             ModContent.ItemType<Items.MysticChandelier>(),
                             0, /* ModContent.ItemType<Items.RoyalChandelier>(), */
                             ModContent.ItemType<Items.AltSandstoneChandelier>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 54)]);
        }
    }
}
