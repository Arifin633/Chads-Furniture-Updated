using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class HardsmithAdmMyt : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Crafting Stations/HardsmithAdmMyt";
        public override void SetStaticDefaults() => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            Item.rare = ItemRarityID.Orange;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Hardsmith>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Hellsmith>())
            .AddIngredient(ItemID.AdamantiteOre, 30)
            .AddIngredient(ItemID.MythrilAnvil)
            .AddTile(TileID.WorkBenches)
            .Register();

            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Blacksmith>())
            .AddIngredient(ItemID.AdamantiteForge, 1)
            .AddIngredient(ItemID.MythrilAnvil, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
