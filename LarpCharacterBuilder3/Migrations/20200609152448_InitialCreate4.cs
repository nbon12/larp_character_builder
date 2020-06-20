using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LarpCharacterBuilder3.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TotalCp = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true),
                    SkillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: true),
                    CharactersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterEvent_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEvent_CharactersId",
                table: "CharacterEvent",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEvent_EventId",
                table: "CharacterEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CharacterId",
                table: "Event",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CharacterId",
                table: "Skill",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillId",
                table: "Skill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterEvent");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
