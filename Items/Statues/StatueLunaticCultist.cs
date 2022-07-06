using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class StatueLunaticCultist : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Statues/StatueLunaticCultist";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunatic Cultist Collectable Inaction Figure");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Statues3x3>();
            Item.placeStyle = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.AncientCultistTrophy)
            .Register();
        }
    }
}
