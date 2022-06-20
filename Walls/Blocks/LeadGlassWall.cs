using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class LeadGlassWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/LeadGlassWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = 0;
            AddMapEntry(new Color(150, 150, 150));
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.LeadGlassWall>();
            return true;
        }
    }
}