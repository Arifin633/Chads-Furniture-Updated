using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Lamps : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Lamps";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AddMapEntry(new Color(253, 221, 3));
            DustType = -1;
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 18)
                CFUtils.ShiftTileX(i, j, 18, skipWire: true);
            else
                CFUtils.ShiftTileX(i, j, 0, set: true, skipWire: true);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 18)
            {
                switch (Main.tile[i, j].TileFrameY / 56)
                {
                    case 0: /* Princess */
                        r = 0.7f;
                        g = 0.9f;
                        b = 1f;
                        break;
                    case 1: /* Mystic */
                        r = 0.7f;
                        g = 0.3f;
                        b = 0.7f;
                        break;
                    case 2: /* Royal */
                        r = 1f;
                        g = 0.95f;
                        b = 0.8f;
                        break;
                    case 3: /* Sandstone */
                        r = 1f;
                        g = 0.5f;
                        b = 0f;
                        break;
                    case 4: /* Paintable */
                        r = g = b = 0.9f;
                        break;
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameX < 18 &&
                Main.tile[i, j].TileFrameY / 56 is 1 or 2 or 3)
            {
                CFUTileDraw.DrawFlame(i, j, spriteBatch);
            }
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.PrinLamp>(),
                             ModContent.ItemType<Items.MysticLamp>(),
                             ModContent.ItemType<Items.RoyalLamp>(),
                             ModContent.ItemType<Items.SandstoneLamp>(),
                             ModContent.ItemType<Items.PaintableLamp>() };
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 56)]);
        }
    }
}
