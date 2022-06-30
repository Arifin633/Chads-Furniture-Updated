using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Altars : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Altars";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(98, 75, 107));
            HitSound = null;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { 26 };
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            float rand = Main.rand.Next(-5, 6) * 0.0025f;
            if (Main.tile[i, j].TileFrameX >= 54)
            {
                r = 0.5f + rand * 2f;
                g = 0.2f + rand;
                b = 0.1f;
            }
            else
            {
                r = 0.31f + rand;
                g = 0.1f;
                b = 0.44f + rand * 2f;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.tile[i, j].TileFrameX >= 54)
            {
                type = DustID.Blood;
            }
            else
            {
                type = (Main.rand.Next(2) == 0) ? DustID.Stone : DustID.Demonite;
            }
            return true;
        }

        public override void KillTile (int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.tile[i, j].TileFrameX >= 54)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath1, new Vector2(i * 16, j * 16));
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Dig, new Vector2(i * 16, j * 16));
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.AltarDemon>(),
                             ModContent.ItemType<Items.AltarCrimson>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 54)]);
        }
    }
}
