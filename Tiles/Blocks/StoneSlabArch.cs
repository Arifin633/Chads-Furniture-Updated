using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class StoneSlabArch : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/StoneSlab";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLargeFrames[Type] = 1;
            TileID.Sets.ForcedDirtMerging[Type] = true;
            DustType = DustID.Stone;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(128, 128, 128));
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tileAbove = Main.tile[i, j - 1];
            Tile tileBelow = Main.tile[i, j + 1];
            int x = 0;
            int y = 0;
            if (!WorldGen.SolidTile(i - 1, j))
            {
                if (!WorldGen.SolidTile(i + 1, j))
                {
                    x = 3;
                }
                else
                {
                    x = 0;
                }
            }
            else if (!WorldGen.SolidTile(i + 1, j))
            {
                x = 2;
            }
            else
            {
                x = 1;
            }

            if (tileAbove.TileType != Type)
            {
                if (tileBelow.TileType != Type)
                {
                    y = 3;
                }
                else
                {
                    y = 0;
                }
            }
            else if (tileBelow.TileType != Type)
            {
                y = 2;
            }
            else
            {
                y = 1;
            }

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            spriteBatch.Draw(
                ModContent.Request<Texture2D>("CFU/Textures/Tiles/Blocks/StoneArch").Value,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle((x * 16), (y * 16), 16, 16),
                Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }
    }
}
