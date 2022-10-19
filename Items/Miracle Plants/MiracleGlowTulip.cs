using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MiracleGlowTulip : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Miracle Plants/MiracleGlowTulip";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miracle Glow Tulip");
            Tooltip.SetDefault("'Can grow anywhere!'");
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
            Item.createTile = ModContent.TileType<Tiles.MiracleGlowTulip>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            /*.AddIngredient(ItemID.GlowTulip)*/
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}