using Microsoft.EntityFrameworkCore.Migrations;

namespace LarpCharacterBuilder3.Migrations
{
    public partial class primarykey3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CharacterSkills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CharacterSkills",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
