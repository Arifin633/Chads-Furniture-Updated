using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class BorealWoodTrellis : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Trellises/BorealWoodTrellis";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            Main.wallLight[Type] = true;
            WallID.Sets.AllowsWind[Type] = true;
            DustType = DustID.BorealWood;
        }
    }
}
