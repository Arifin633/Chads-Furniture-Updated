using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Larva : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Larva";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(254, 156, 12));
            TileID.Sets.DisableSmartCursor[Type] = true;
            AnimationFrameHeight = 54;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short x, ref short y)
        {
            offsetY = -2;
        }
        
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 17)
            {
                frameCounter = 0;
                frame = ++frame % 7;
            }
        }
        
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.Larva>());
        }
    }
}
