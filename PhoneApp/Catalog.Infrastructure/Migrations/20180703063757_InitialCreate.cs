using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 1, "Galaxy S9 256GB (Unlocked)", "http://s7d2.scene7.com/is/image/SamsungUS/S9Plus_front_gold?$product-details-jpg$", "Samsung Galaxy S9 256GB", 959.99m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 2, "Galaxy S9 128GB (Unlocked)", "http://s7d2.scene7.com/is/image/SamsungUS/S9Plus_l30_gold?$product-details-jpg$", "Samsung Galaxy S9 128GB", 889.99m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 3, "Galaxy S8 64GB (Unlocked)", "http://s7d2.scene7.com/is/image/SamsungUS/S8Plus_Black_Front_032317?$product-details-jpg$", "Samsung Galaxy S8 64GB", 589.99m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 4, "Samsung Galaxy S8 Active 64GB (Sp)", "http://s7d2.scene7.com/is/image/SamsungUS/spr_g892u_s8_active_gy_v_front_lock?$default-jpg$", "Samsung Galaxy S8 Active 64GB", 850m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 5, "Galaxy S7 32GB (TMob)", "http://s7d2.scene7.compubli/is/image/SamsungUS/SMG930s7_hero_102116?$default-jpg$", "Samsung Galaxy S7 32GB", 473m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
