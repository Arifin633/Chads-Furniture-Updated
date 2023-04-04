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
            DustType = DustID.RichMahogany;
        }
    }
}
