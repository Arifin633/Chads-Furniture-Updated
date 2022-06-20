﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class Wallomatic : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/Wallomatic";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                18
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Wall-O-Matic");
            AddMapEntry(new Color(81, 81, 89), name);
            AnimationFrameHeight = 54;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if ((++frameCounter >= 6 && frame != 0) || frameCounter >= 24)
            {
                frameCounter = 0;
                frame = ++frame % 12;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Wallomatic>());
        }
    }
}