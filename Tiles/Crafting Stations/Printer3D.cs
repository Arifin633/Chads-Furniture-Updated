﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    class Printer3D : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/Printer3D";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(81, 81, 89));
            DustType = -1;
            AnimationFrameHeight = 36;
        }

        int CurFrame = 0;
        readonly int[] ActFrames =
            { 0, 1, 2, 3, 4, 5, 2, 3, 4, 5, 2, 3, 4, 5, 1, 0,
              6, 7, 8, 9, 10,11, 12, 13, 14, 15, 16, 13, 14,
              15, 16, 13, 14, 15, 16, 12, 11, 10, 9, 8, 7, 6 };

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 6)
            {
                frameCounter = 0;
                /* This assignment isn't strictly necessary, but the variable
                   could otherwise cause an overflow if enough frames went by. */
                CurFrame = ++CurFrame % 41;
                frame = ActFrames[CurFrame];
            }
        }
    }
}
