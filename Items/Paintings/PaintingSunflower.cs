using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class PaintingSunflower : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Paintings/PaintingSunflower";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunflower");
            Tooltip.SetDefault("'X. Zimur'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            // Item.value = 10000;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Paintings2xX>();
            Item.placeStyle = 3;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Paper>())
            .AddTile(ModContent.TileType<Tiles.Easel>())
            .Register();
        }
    }
}

