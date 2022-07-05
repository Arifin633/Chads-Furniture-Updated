using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class PearlwoodTrellis : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Trellises/PearlwoodTrellis";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            Main.wallLight[Type] = true;
            WallID.Sets.AllowsWind[Type] = true;
            DustType = DustID.Pearlwood;
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.PearlwoodTrellis>();
            return true;
        }
    }
}
