using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PrinBookcase : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Princess/PrinBookcase";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Princess Bookcase");
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
            Item.createTile = ModContent.TileType<Tiles.Bookcases>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>())
            .AddIngredient(ItemID.Pearlwood, 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
