using Microsoft.EntityFrameworkCore.Migrations;

namespace LarpCharacterBuilder3.Migrations
{
    public partial class CharacterSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvent_Character_CharactersId",
                table: "CharacterEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvent_Event_EventId",
                table: "CharacterEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Character_CharacterId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_CharacterId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterEvent",
                table: "CharacterEvent");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "CharacterEvent",
                newName: "CharacterEvents");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterEvent_EventId",
                table: "CharacterEvents",
                newName: "IX_CharacterEvents_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterEvent_CharactersId",
                table: "CharacterEvents",
                newName: "IX_CharacterEvents_CharactersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterEvents",
                table: "CharacterEvents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<long>(nullable: false),
                    SkillId = table.Column<long>(nullable: false),
                    SkillId1 = table.Column<int>(nullable: true),
                    CharacterId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Character_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skill_SkillId1",
                        column: x => x.SkillId1,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_CharacterId1",
                table: "CharacterSkills",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId1",
                table: "CharacterSkills",
                column: "SkillId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvents_Character_CharactersId",
                table: "CharacterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterEvents_Event_EventId",
                table: "CharacterEvents");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterEvents",
                table: "CharacterEvents");

            migrationBuilder.RenameTable(
                name: "CharacterEvents",
                newName: "CharacterEvent");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterEvents_EventId",
                table: "CharacterEvent",
                newName: "IX_CharacterEvent_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterEvents_CharactersId",
                table: "CharacterEvent",
                newName: "IX_CharacterEvent_CharactersId");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Skill",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterEvent",
                table: "CharacterEvent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CharacterId",
                table: "Skill",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterEvent_Character_CharactersId",
                table: "CharacterEvent",
                column: "CharactersId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterEvent_Event_EventId",
                table: "CharacterEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Character_CharacterId",
                table: "Skill",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
