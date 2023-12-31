using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Stardust : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Materials/Stardust";
        public override void SetStaticDefaults() => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe(10)
            .AddIngredient(ItemID.FallenStar)
            .AddTile(TileID.Bottles)
            .Register();
        }
    }
}
