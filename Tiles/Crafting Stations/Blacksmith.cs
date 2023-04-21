using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class Blacksmith : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/Blacksmith";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(144, 148, 144));
            AdjTiles = new int[] { TileID.Furnaces, TileID.Anvils };
            AnimationFrameHeight = 56;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            r = 0.7f;
            g = 0.5f;
            b = 0.5f;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            type = (Main.rand.NextBool(2))
                ? DustID.Iron : DustID.Stone;
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CFUTileDraw.ForgeDrawSmoke(i, j, spriteBatch, "BlacksmithSmoke", 32, 26, Type);
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 6)
            {
                frameCounter = 0;
                frame = ++frame % 5;
            }
        }
    }
}
