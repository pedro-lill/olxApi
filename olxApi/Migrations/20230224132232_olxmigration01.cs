using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace olxApi.Migrations
{
    public partial class olxmigration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "state",
                table: "Anuncios",
                newName: "idState");

            migrationBuilder.RenameColumn(
                name: "cat",
                table: "Anuncios",
                newName: "idCat");

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Anuncios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "state_id",
                table: "Anuncios",
                type: "character varying(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Anuncios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_category_id",
                table: "Anuncios",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_state_id",
                table: "Anuncios",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_user_id",
                table: "Anuncios",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Categories_category_id",
                table: "Anuncios",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_States_state_id",
                table: "Anuncios",
                column: "state_id",
                principalTable: "States",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Users_user_id",
                table: "Anuncios",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Categories_category_id",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_States_state_id",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Users_user_id",
                table: "Anuncios");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_category_id",
                table: "Anuncios");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_state_id",
                table: "Anuncios");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_user_id",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "state_id",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Anuncios");

            migrationBuilder.RenameColumn(
                name: "idState",
                table: "Anuncios",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "idCat",
                table: "Anuncios",
                newName: "cat");
        }
    }
}
