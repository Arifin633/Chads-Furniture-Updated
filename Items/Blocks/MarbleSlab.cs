using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MarbleSlab : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Blocks/MarbleSlab";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Slab");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.MarbleSlab>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MarbleBlock, 1)
            .AddIngredient(ItemID.StoneBlock, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}