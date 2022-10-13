using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WardrobeAsh : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wardrobes/WardrobeAsh";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash Wood Wardrobe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Wardrobes>();
            Item.placeStyle = 9;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            //.AddIngredient(ItemID.AshWood, 20) TODO: Uncomment in 1.4.4
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}