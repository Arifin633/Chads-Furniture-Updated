using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Plant3 : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Garden/Plants/Plant3";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plant");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Plants>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrassSeeds, 1)
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}
