using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CurtainRoyal : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Curtains/CurtainRoyal";
        public override void SetStaticDefaults() => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.CurtainRoyal>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
            .AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<Tiles.SpinningWheel>())
            .Register();
        }
    }
}
