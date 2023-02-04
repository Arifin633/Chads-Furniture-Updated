using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallClockSteam : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wall Clocks/WallClockSteam";
        public override void SetStaticDefaults() => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.WallClocks>();
            Item.placeStyle = 24;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ItemID.Cog, 5)
            .AddTile(TileID.SteampunkBoiler)
            .Register();


        }
    }
}
