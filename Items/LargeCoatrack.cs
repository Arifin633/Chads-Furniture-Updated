using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LargeCoatrack : ModItem
    {
        public override string Texture => "CFU/Textures/Items/LargeCoatrack";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coatrack");
            Tooltip.SetDefault("'A large coatrack'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.LargeCoatrack>();
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
