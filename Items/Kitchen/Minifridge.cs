using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Minifridge : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Kitchen/Minifridge";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Minifridge");
            Tooltip.SetDefault("'Generally used for food.'");
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
            Item.createTile = ModContent.TileType<Tiles.Minifridge>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
