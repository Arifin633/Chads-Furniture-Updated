using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleCattails : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleCattails";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 9;
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.AnchorAlternateTiles = new int[] { Type };
            // TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.OnlyInLiquid;
            // TileObjectData.addSubTile(3);
            // TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newSubTile.AnchorAlternateTiles = new int[] { Type };
            // TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.NotAllowed;
            // TileObjectData.addSubTile(6);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(28, 216, 109));
            AddMapEntry(new Color(107, 182, 0));
            AddMapEntry(new Color(75, 184, 230));
            AddMapEntry(new Color(208, 80, 80));
            AddMapEntry(new Color(141, 137, 223));
            AddMapEntry(new Color(182, 175, 130));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 18);

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 18)
            {
                case 0:
                    type = DustID.GrassBlades;
                    break;
                case 1:
                    type = DustID.JunglePlants;
                    break;
                case 2:
                    type = DustID.HallowedPlants;
                    break;
                case 3:
                    type = DustID.CrimsonPlants;
                    break;
                case 4:
                    type = DustID.CorruptPlants;
                    break;
                case 5:
                    type = DustID.Bone;
                    break;
            }
            return true;
        }

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            /* Glossary:
              
               0  <- Flower | Underwater Flower ->  o
               |  <- Stem                           |
              \|/ <- Base                          \|/

            */

            Tile tileBelow = Main.tile[i, (j + 1)];
            Tile tile = Main.tile[i, j];

            /* The following block was added as a workaround
               to the tile object system not working in con-
               junction with tile wands. */
            if ((tile.TileFrameX / 18) is 0 or 1 or 2)
            {
                if (tileBelow.TileType == Type)
                    if (tile.LiquidAmount > 1)
                        tile.TileFrameX = (short)(18 * Main.rand.Next(3, 5));
                    else
                        tile.TileFrameX = (short)(18 * Main.rand.Next(6, 8));
            }
            else if (tileBelow.TileType != Type)
                tile.TileFrameX = (short)(18 * Main.rand.Next(0, 2));
            /**/

            if ((tileBelow.TileType == Type) &&
                (tile.TileFrameX / 18) is not 0 or 1 or 2) /* if (alternate != 0) */
            {
                /* If we're above a non-connecting base,
                   shift it to the connecting version. */
                if ((tileBelow.TileFrameX / 18) is 0 or 1 or 2)
                {
                    tileBelow.TileFrameX = (short)(18 * Main.rand.Next(9, 11));
                }
                else
                {
                    switch (tile.TileFrameX / 18)
                    {
                        /* Each of the three surface flower variations
                           have a special corresponding stem.  If we
                           are placing one, shift the stem below to
                           correct version... */
                        case 6:
                            tileBelow.TileFrameX = (18 * 13);
                            break;
                        case 7:
                            tileBelow.TileFrameX = (18 * 14);
                            break;
                        case 8:
                            tileBelow.TileFrameX = (18 * 15);
                            break;
                        /* ...and if we're not, use the regular stem. */
                        default:
                            tileBelow.TileFrameX = (18 * 12);
                            break;
                    }

                    /* If the tile below the one we just currently turned into
                       a stem happens to be one of the special stems mentioned
                       above, turn it into a regular stem. */
                    Tile tileBelowBelow = Main.tile[i, (j + 2)];
                    if (tileBelowBelow.TileType == Type &&
                        (tileBelowBelow.TileFrameX / 18) is 13 or 14 or 15)
                    {
                        tileBelowBelow.TileFrameX = (18 * 12);
                        /* If we're in multiplayer update
                           the tile, since we changed it. */
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            NetMessage.SendTileSquare(-1, i, (j + 2));
                    }
                }
                /* The tile below is always changed, so we always
                   update it assuming we're in multiplayer.*/
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendTileSquare(-1, i, (j + 1));
            }
            return 1;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail || effectOnly)
                return;

            Tile tileBelow = Main.tile[i, (j + 1)];
            if (tileBelow.TileType == Type)
            {
                /* By adding a new special point as soon as a cattail piece
                   is destroyed we avoid the flickering that would otherwise
                   happen between the time of death and the placement of a
                   a new point in `PostDraw'. */
                if (CFUConfig.WindEnabled())
                    CFUTileDraw.AddSpecialPosition(i, (j + 1), CFUTileDraw.SpecialPositionType.RisingTile);

                /* If we're above a connecting base, turn it
                   into a stubby non-connecting base. */
                if ((tileBelow.TileFrameX / 18) is 9 or 10 or 11)
                {
                    tileBelow.TileFrameX = (short)(18 * Main.rand.Next(0, 2));
                }
                else
                {
                    /* If we're underwater, turn the tile
                       below into an underwater flower,... */
                    if (tileBelow.LiquidAmount > 0)
                    {
                        tileBelow.TileFrameX = (18 * 3);
                    }
                    else
                    {
                        /* ...otherwise, use one of the surface flowers... */
                        int frameX = (18 * Main.rand.Next(6, 8));
                        tileBelow.TileFrameX = (short)frameX;

                        /* ...and, if the surface flower we just placed
                           has a stem below it, turn it into the correct
                           special stem variation. */
                        Tile tileBelowBelow = Main.tile[i, (j + 2)];
                        if (tileBelowBelow.TileType == Type &&
                            (tileBelowBelow.TileFrameX / 18) is 12)
                        {
                            switch (frameX / 18)
                            {
                                case 6:
                                    tileBelowBelow.TileFrameX = (18 * 13);
                                    break;
                                case 7:
                                    tileBelowBelow.TileFrameX = (18 * 14);
                                    break;
                                case 8:
                                    tileBelowBelow.TileFrameX = (18 * 15);
                                    break;
                            }

                            /* If we're in multiplayer update
                               the tile, since we changed it. */
                            if (frameX is 6 or 7 or 8 &&
                                Main.netMode == NetmodeID.MultiplayerClient)
                                NetMessage.SendTileSquare(-1, i, (j + 2));
                        }
                    }
                }
                /* The tile below is always changed, so we always
                   update it assuming we're in multiplayer.*/
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendTileSquare(-1, i, (j + 1));
            }
        }

        // public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        // {
        //     if (i % 2 == 0)
        //         spriteEffects = SpriteEffects.FlipHorizontally;
        // }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) =>
            offsetY = 2;

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j - 1].TileType != Type))
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ItemID.GrassSeeds,
                             ItemID.JungleGrassSeeds,
                             ItemID.HallowedSeeds,
                             ItemID.CrimsonSeeds,
                             ItemID.CorruptSeeds,
                             ItemID.GlowingMushroom };
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 18)]);
        }
    }
}
