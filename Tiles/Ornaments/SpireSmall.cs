using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class SpireSmall : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Ornaments/SpireSmall";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(160, 156, 146));
            AddMapEntry(new Color(128, 128, 128));
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.tile[i, j].TileFrameX >= 36)
            {
                type = DustID.Stone;
            }
            else
            {
                type = DustID.MothronEgg;
            }
            return true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.LimestoneSpireSmall>(),
                             ModContent.ItemType<Items.StoneSpireSmall>() };
            yield return new Item(styles[(Main.tile[i, j].TileFrameX / 36)]);
        }
    }
}
