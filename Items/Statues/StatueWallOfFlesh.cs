using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class StatueWallOfFlesh : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Statues/StatueWallOfFlesh";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wall of Flesh Collectable Inaction Figure");
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
            Item.createTile = ModContent.TileType<Tiles.Statues3x3>();
            Item.placeStyle = 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.WallofFleshTrophy)
            .Register();
        }
    }
}
