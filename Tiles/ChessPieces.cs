using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class ChessPieces : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/ChessPieces";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            // TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                18
            };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Height = 2;
            TileObjectData.newSubTile.Origin = new Point16(0, 1);
            TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addSubTile(14);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Height = 2;
            TileObjectData.newSubTile.Origin = new Point16(0, 1);
            TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addSubTile(15);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
            // TileObjectData.addAlternate(1);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            // TileObjectData.addAlternate(2);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chess");
            AddMapEntry(new Color(168, 178, 204), name);
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.KingWhite>(),
                             ModContent.ItemType<Items.KingBlack>(),
                             ModContent.ItemType<Items.QueenWhite>(),
                             ModContent.ItemType<Items.QueenBlack>(),
                             ModContent.ItemType<Items.BishopWhite>(),
                             ModContent.ItemType<Items.BishopWhite>(),
                             ModContent.ItemType<Items.BishopBlack>(),
                             ModContent.ItemType<Items.BishopBlack>(),
                             ModContent.ItemType<Items.KnightWhite>(),
                             ModContent.ItemType<Items.KnightWhite>(),
                             ModContent.ItemType<Items.KnightBlack>(),
                             ModContent.ItemType<Items.KnightBlack>(),
                             ModContent.ItemType<Items.RookWhite>(),
                             ModContent.ItemType<Items.RookBlack>(),
                             ModContent.ItemType<Items.PawnWhite>(),
                             ModContent.ItemType<Items.PawnBlack>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 36)]);
        }
    }
}
