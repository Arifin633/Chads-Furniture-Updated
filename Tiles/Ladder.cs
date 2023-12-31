using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class Ladder : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Ladder";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            AddMapEntry(new Color(191, 142, 111));
            DustType = DustID.Dirt;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            // Top of the ladder.
            if (Main.tile[i, j - 1].TileType != Type)
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                var texture = Main.instance.TilesRenderer.GetTileDrawTexture(tile, i, j);
                spriteBatch.Draw(
                    texture,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tile.TileFrameX, tile.TileFrameY + 90, 16, 16),
                    Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
