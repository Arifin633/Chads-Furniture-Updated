using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Cobweb : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Blocks/Cobweb";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sturdy Cobweb");
            Tooltip.SetDefault("'Doesn't break as easily'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Cobweb>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Cobweb, 4)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}