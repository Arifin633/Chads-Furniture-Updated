using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallCandelabraCrystal : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wall Candelabras/WallCandelabraCrystal";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Wall Candelabra");
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
            Item.createTile = ModContent.TileType<Tiles.WallCandelabras>();
            Item.placeStyle = 32;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CrystalBlock, 12)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
