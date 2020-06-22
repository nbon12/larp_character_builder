using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LarpCharacterBuilder3.Migrations
{
    public partial class CharacterEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvents_Character_CharactersId",
                table: "CharacterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvents_Event_EventId",
                table: "CharacterEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterEvents",
                table: "CharacterEvents");

            migrationBuilder.DropIndex(
                name: "IX_CharacterEvents_CharactersId",
                table: "CharacterEvents");

            migrationBuilder.DropIndex(
                name: "IX_CharacterEvents_EventId",
                table: "CharacterEvents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CharacterEvents");

            migrationBuilder.DropColumn(
                name: "CharactersId",
                table: "CharacterEvents");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "CharacterEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CharacterId",
                table: "CharacterEvents",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId1",
                table: "CharacterEvents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "CharacterEvents",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterEvents",
                table: "CharacterEvents",
                columns: new[] { "CharacterId", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEvents_CharacterId1",
                table: "CharacterEvents",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEvents_EventId1",
                table: "CharacterEvents",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterEvents_Character_CharacterId1",
                table: "CharacterEvents",
                column: "CharacterId1",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterEvents_Event_EventId1",
                table: "CharacterEvents",
                column: "EventId1",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvents_Character_CharacterId1",
                table: "CharacterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvents_Event_EventId1",
                table: "CharacterEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterEvents",
                table: "CharacterEvents");

            migrationBuilder.DropIndex(
                name: "IX_CharacterEvents_CharacterId1",
                table: "CharacterEvents");

            migrationBuilder.DropIndex(
                name: "IX_CharacterEvents_EventId1",
                table: "CharacterEvents");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "CharacterEvents");

            migrationBuilder.DropColumn(
                name: "CharacterId1",
                table: "CharacterEvents");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "CharacterEvents");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "CharacterEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CharacterEvents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CharactersId",
                table: "CharacterEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterEvents",
                table: "CharacterEvents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEvents_CharactersId",
                table: "CharacterEvents",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEvents_EventId",
                table: "CharacterEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterEvents_Character_CharactersId",
                table: "CharacterEvents",
                column: "CharactersId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterEvents_Event_EventId",
                table: "CharacterEvents",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
