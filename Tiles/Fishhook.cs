using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Fishhook : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Fishhook";

        static readonly int[] Fishes = {
            -2,   // Fish Outline
            -1,   // Empty
            2290, // Bass
            2297, // Trout
            2298, // Salmon
            2299, // Atlantic Cod
            2300, // Tuna
            2301, // Red Snapper
            2302, // Neon Tetra
            2303, // Armored Cavefish
            2304, // Damselfish
            2305, // Crimson Tigerfish
            2306, // Frost Minnow
            2307, // Princess Fish
            2308, // Golden Carp
            2309, // Specular Fish
            2310, // Prismite
            2311, // Variegated Lardfish
            2312, // Flarefin Koi
            2313, // Double Cod
            2314, // Honeyfin
            2315, // Obsifish
            2317, // Chaos Fish
            2318, // Ebonkoi
            2319, // Hemopiranha
            2321, // Stinkfish
        };

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateWidth = 22;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(81, 81, 89));
            AddMapEntry(new Color(100, 100, 74));
            DustType = -1;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)((Main.tile[i, j].TileFrameY == 0) ? 0 : 1);

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            CFUtils.ShiftTileX(i, j, 24, set: true);
            return 1;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            int frameX = Main.tile[i, j].TileFrameX;
            if (frameX >= 48)
                player.cursorItemIconID = Fishes[(frameX / 24)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            bool client = (Main.netMode == NetmodeID.MultiplayerClient);

            if (frameX >= 48)
            {
                int item = Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, Fishes[(frameX / 24)]);
                if (client)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item);
                }

                CFUtils.ShiftTileX(i, j, 24, set: true);
            }

            int index = System.Array.IndexOf(Fishes, player.inventory[player.selectedItem].type);
            if (index != -1)
            {
                CFUtils.ShiftTileX(i, j, (short)(index * 24), set: true);
                Main.mouseItem.stack--;
                player.inventory[player.selectedItem].stack--;
                if (player.inventory[player.selectedItem].stack <= 0)
                {
                    player.inventory[player.selectedItem].SetDefaults();
                    Main.mouseItem.SetDefaults();
                }
            }

            player.releaseUseItem = false;
            player.mouseInterface = true;
            return true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            if (frameX >= 48)
                yield return new Item(Fishes[(frameX / 24)]);
            yield return new Item(ModContent.ItemType<Items.Fishhook>());
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) => width = 22;

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j].TileFrameY == 0))
            {
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingTile);
            }
        }
    }
}
