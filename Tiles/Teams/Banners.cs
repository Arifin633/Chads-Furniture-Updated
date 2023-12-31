using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Banners : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Teams/Banners";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(13, 88, 130));
            DustType = -1;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j].TileFrameY == 0))
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingTile);
        }
    }
}
