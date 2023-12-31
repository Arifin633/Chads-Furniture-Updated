using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class OrganPipe : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/OrganPipe";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Bone;
            AddMapEntry(new Color(202, 197, 191));
        }

        /* This draws the Organ Pipe under the tile directly above it.
           ...
           I have no idea why.*/
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if ((Main.tile[i, j - 1].HasTile) &&
                (Main.tileSolid[Main.tile[i, j - 1].TileType]) &&
                (Main.tile[i, j + 1].TileType == Type))
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(Texture).Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(0, 0, 16, 16),
                    Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(Texture).Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(0, 0, 16, 16),
                    Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else return true;
        }
    }
}
