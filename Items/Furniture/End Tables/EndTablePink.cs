using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class EndTablePink : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/End Tables/EndTablePink";
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
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.EndTables>();
            Item.placeStyle = 27;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PinkBrick, 12)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
