using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ObjectInteractions;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Clocks : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Clocks";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/ClocksHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.Clock[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16,
                18
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Clock");
            AddMapEntry(new Color(181, 172, 190), name);
            DustType = -1;
            AdjTiles = new int[] { TileID.GrandfatherClocks };
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool RightClick(int x, int y)
        {
            CFUtils.PrintTime();
            return true;
        }

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinClock>(),
              ModContent.ItemType<Items.MysticClock>(),
              ModContent.ItemType<Items.RoyalClock>(),
              ModContent.ItemType<Items.AltSandstoneClock>() };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 92)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameY / 92)]);
        }
    }
}
