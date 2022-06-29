using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class FallenLog : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/FallenLog";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Log");
            Tooltip.SetDefault("'*A plastic replica'\n'Fairies can't tell the difference!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.FallenLog>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 40)
            .AddIngredient(ItemID.FairyCritterPink, 1)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();

            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 40)
            .AddIngredient(ItemID.FairyCritterBlue, 1)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();

            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 40)
            .AddIngredient(ItemID.FairyCritterGreen, 1)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();
        }
    }
}