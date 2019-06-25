using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactRummy.Migrations
{
    public partial class card_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                columns: new[] { "Suit", "Value", "GameID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Cards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                columns: new[] { "Suit", "Value" });
        }
    }
}
