using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class BorealWoodTrellis : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Trellises/BorealWoodTrellis";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boreal Wood Trellis");
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
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.BorealWoodTrellis>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
            .AddIngredient(ItemID.BorealWood, 1)
            .AddTile(TileID.WorkBenches)
            .Register();

            Mod.CreateRecipe(ItemID.BorealWood)
            .AddIngredient(this, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}