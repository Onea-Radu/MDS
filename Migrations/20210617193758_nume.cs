using Microsoft.EntityFrameworkCore.Migrations;

namespace EmagClone.Migrations
{
    public partial class nume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductsUsers_Products_ProductId",
                table: "CartProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductsUsers_AspNetUsers_UserId",
                table: "CartProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsUsers_Products_ProductId",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsUsers_AspNetUsers_UserId",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProductsUsers",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteProductsUsers_ProductId",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProductsUsers",
                table: "CartProductsUsers");

            migrationBuilder.DropIndex(
                name: "IX_CartProductsUsers_ProductId",
                table: "CartProductsUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FavoriteProductsUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CartProductsUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProductsUsers",
                table: "FavoriteProductsUsers",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProductsUsers",
                table: "CartProductsUsers",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductsUsers_Products_ProductId",
                table: "CartProductsUsers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductsUsers_AspNetUsers_UserId",
                table: "CartProductsUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsUsers_Products_ProductId",
                table: "FavoriteProductsUsers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsUsers_AspNetUsers_UserId",
                table: "FavoriteProductsUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductsUsers_Products_ProductId",
                table: "CartProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductsUsers_AspNetUsers_UserId",
                table: "CartProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsUsers_Products_ProductId",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProductsUsers_AspNetUsers_UserId",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProductsUsers",
                table: "FavoriteProductsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProductsUsers",
                table: "CartProductsUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FavoriteProductsUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CartProductsUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProductsUsers",
                table: "FavoriteProductsUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProductsUsers",
                table: "CartProductsUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProductsUsers_ProductId",
                table: "FavoriteProductsUsers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductsUsers_ProductId",
                table: "CartProductsUsers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductsUsers_Products_ProductId",
                table: "CartProductsUsers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductsUsers_AspNetUsers_UserId",
                table: "CartProductsUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsUsers_Products_ProductId",
                table: "FavoriteProductsUsers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProductsUsers_AspNetUsers_UserId",
                table: "FavoriteProductsUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
