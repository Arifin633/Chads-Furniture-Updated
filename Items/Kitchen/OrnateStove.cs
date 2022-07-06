using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class OrnateStove : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Kitchen/OrnateStove";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ornate Stove");
            Tooltip.SetDefault("Used for smelting ore\nUsed for cooking food\n'Looks fancier and older than a normal stove'");
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
            Item.createTile = ModContent.TileType<Tiles.Stoves>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ItemID.Cog, 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
