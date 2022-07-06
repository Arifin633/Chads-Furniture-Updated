using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysteriousTablet : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/MysteriousTablet";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decorative Mysterious Tablet");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.MysteriousTablet>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FragmentVortex, 4)
            .AddIngredient(ItemID.FragmentNebula, 4)
            .AddIngredient(ItemID.FragmentSolar, 4)
            .AddIngredient(ItemID.FragmentStardust, 4)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}