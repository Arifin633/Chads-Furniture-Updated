using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class RichMahoganyTrellis : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Trellises/RichMahoganyTrellis";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            Main.wallLight[Type] = true;
            WallID.Sets.AllowsWind[Type] = true;
            DustType = 0;
            AddMapEntry(new Color(150, 150, 150));
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.RichMahoganyTrellis>();
            return true;
        }
    }
}
