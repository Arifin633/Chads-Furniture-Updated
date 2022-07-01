using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Stalactites : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Stalactites";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(21);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(24);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(27);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(30);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(33);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorTop = AnchorData.Empty;
            TileObjectData.addAlternate(36);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(128, 128, 128));

            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            if (frameY < 36)
                offsetY = -2;
            else
                offsetY = 2;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 54)
            {
                case 0:
                case 1:
                    type = DustID.Stone;
                    break;
                case 2:
                    type = DustID.Demonite;
                    break;
                case 3:
                    type = DustID.Crimstone;
                    break;
                case 4:
                    type = DustID.Sluggy;
                    break;
                case 5:
                    type = DustID.Granite;
                    break;
                case 6:
                    type = DustID.Marble;
                    break;
                case 7:
                    type = DustID.Web;
                    break;
                case 8:
                    type = DustID.Ice_Pink;
                    break;
                case 9:
                    type = DustID.Ice_Purple;
                    break;
                case 10:
                    type = DustID.Ice_Red;
                    break;
                case 11:
                    type = DustID.Ice;
                    break;
            }
            return true;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.StoneStalactite>(),
                             ModContent.ItemType<Items.HallowedStalactite>(),
                             ModContent.ItemType<Items.CorruptStalactite>(),
                             ModContent.ItemType<Items.CrimsonStalactite>(),
                             ModContent.ItemType<Items.SandstoneStalactite>(),
                             ModContent.ItemType<Items.GraniteStalactite>(),
                             ModContent.ItemType<Items.MarbleStalactite>(),
                             ModContent.ItemType<Items.SpiderStalactite>(),
                             ModContent.ItemType<Items.HallowedIceStalactite>(),
                             ModContent.ItemType<Items.CorruptIceStalactite>(),
                             ModContent.ItemType<Items.CrimsonIceStalactite>(),
                             ModContent.ItemType<Items.IceStalactite>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 54)]);
        }
    }
}
