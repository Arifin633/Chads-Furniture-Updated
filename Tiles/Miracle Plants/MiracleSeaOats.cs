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
    public class MiracleSeaOats : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleSeaOats";

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
            TileObjectData.newTile.StyleWrapLimit = 15;
            // TileObjectData.newTile.StyleMultiplier = 5;
            // TileObjectData.newTile.RandomStyleRange = 5;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(99, 150, 8));
            AddMapEntry(new Color(139, 154, 64));
            AddMapEntry(new Color(34, 129, 168));
            AddMapEntry(new Color(180, 82, 82));
            AddMapEntry(new Color(113, 108, 205));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 34);

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 34)
            {
                case 0:
                    type = DustID.SeaOatsOasis;
                    break;
                case 1:
                    type = DustID.SeaOatsBeach;
                    break;
                case 2:
                    type = DustID.HallowedPlants;
                    break;
                case 3:
                    type = DustID.CrimsonPlants;
                    break;
                case 4:
                    type = DustID.CorruptPlants;
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
                             ItemID.GrassSeeds,
                             ItemID.HallowedSeeds,
                             ItemID.CrimsonSeeds,
                             ItemID.CorruptSeeds };
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 34)]);
        }
    }
}
