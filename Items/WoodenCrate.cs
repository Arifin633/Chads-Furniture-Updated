using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WoodenCrate : ModItem
    {
        public override string Texture => "CFU/Textures/Items/WoodenCrate";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Wooden Crate");
            Tooltip.SetDefault("'Can be stacked on top of eachother'");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.WoodenCrate>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 15)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
