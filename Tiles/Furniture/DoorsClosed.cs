using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class DoorsClosed : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/DoorsClosed";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/DoorsClosedHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.NotReallySolid[Type] = true;
            TileID.Sets.DrawsWalls[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.OpenDoorID[Type] = ModContent.TileType<Tiles.DoorsOpen>();
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 1);
            TileObjectData.addAlternate(0);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 2);
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            AdjTiles = new int[] { TileID.ClosedDoor };
            AddMapEntry(new Color(181, 172, 190));
            DustType = -1;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinDoor>(),
              ModContent.ItemType<Items.MysticDoor>(),
              ModContent.ItemType<Items.RoyalDoor>(),
              ModContent.ItemType<Items.SandstoneDoor>()};

        public override void MouseOver(int i, int j)
        {

            Player player = Main.LocalPlayer;
            player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 54)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(Styles[(Main.tile[i, j].TileFrameY / 54)]);
        }
    }
}
