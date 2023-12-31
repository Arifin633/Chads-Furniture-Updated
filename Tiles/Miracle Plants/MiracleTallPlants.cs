using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleTallPlants : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleTallPlants";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 32 };
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 20;
            // TileObjectData.newTile.StyleMultiplier = 20;
            // TileObjectData.newTile.RandomStyleRange = 12;
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 16;
            // TileObjectData.addSubTile(1);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 14;
            // TileObjectData.addSubTile(2);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 14;
            // TileObjectData.addSubTile(3);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 14;
            // TileObjectData.addSubTile(4);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 12;
            // TileObjectData.addSubTile(5);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 6;
            // TileObjectData.addSubTile(6);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 12;
            // TileObjectData.addSubTile(7);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 20;
            // TileObjectData.addSubTile(8);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 6;
            // TileObjectData.addSubTile(9);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.RandomStyleRange = 10;
            // TileObjectData.addSubTile(10);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(27, 197, 109));
            AddMapEntry(new Color(96, 197, 27));
            AddMapEntry(new Color(48, 208, 234));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j)
        {
            switch (Main.tile[i, j].TileFrameY / 34)
            {
                case 7 or 8:
                    return 1;
                case 9 or 10:
                    return 2;
                default:
                    return 0;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 34)
            {
                case 7 or 8:
                    type = DustID.JunglePlants;
                    break;
                case 9 or 10:
                    type = DustID.HallowedPlants;
                    break;
                default:
                    type = DustID.GrassBlades;
                    break;
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY -= 12;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ItemID.GrassSeeds,
                             ItemID.FlowerPacketWhite,
                             ItemID.FlowerPacketYellow,
                             ItemID.FlowerPacketRed,
                             ItemID.FlowerPacketMagenta,
                             ItemID.FlowerPacketPink,
                             ItemID.FlowerPacketBlue,
                             ItemID.JungleGrassSeeds,
                             ItemID.JungleGrassSeeds,
                             ItemID.HallowedSeeds,
                             ItemID.HallowedSeeds };
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 34)]);
        }
    }
}
