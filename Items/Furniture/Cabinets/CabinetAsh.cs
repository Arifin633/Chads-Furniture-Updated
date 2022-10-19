using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CabinetAsh : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Cabinets/CabinetAsh";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash Wood Cabinet");
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
            Item.createTile = ModContent.TileType<Tiles.Cabinets>();
            Item.placeStyle = 42;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            //.AddIngredient(ItemID.AshWood, 10) TODO: Uncomment in 1.4.4
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}