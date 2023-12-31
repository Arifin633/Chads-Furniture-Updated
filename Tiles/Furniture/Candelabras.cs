using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Candelabras : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Candelabras";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };
            AddMapEntry(new Color(253, 221, 3));
            DustType = -1;
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 36)
                CFUtils.ShiftTileX(i, j, 36, skipWire: true);
            else
                CFUtils.ShiftTileX(i, j, 0, set: true, skipWire: true);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 36)
            {
                switch (Main.tile[i, j].TileFrameY / 38)
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
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameX < 36)
            {
                CFUTileDraw.DrawFlame(i, j, spriteBatch);
            }
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.PrinCandelabra>(),
                             ModContent.ItemType<Items.MysticCandelabra>(),
                             ModContent.ItemType<Items.RoyalCandelabra>(),
                             ModContent.ItemType<Items.SandstoneCandelabra>()};
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 38)]);
        }
    }
}
