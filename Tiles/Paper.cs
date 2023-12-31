using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Paper : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Paper";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(197, 183, 166));
            DustType = -1;
            HitSound = SoundID.Grass;
        }
    }
}
