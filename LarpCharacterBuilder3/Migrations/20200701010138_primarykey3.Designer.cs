﻿// <auto-generated />
using System;
using LarpCharacterBuilder3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LarpCharacterBuilder3.Migrations
{
    [DbContext(typeof(LarpBuilderContext))]
    [Migration("20200701010138_primarykey3")]
    partial class primarykey3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LarpCharacterBuilder3.Models.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("StartingCp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.CharacterEvent", b =>
                {
                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("CharacterId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("CharacterEvents");
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.CharacterSkill", b =>
                {
                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<long>("SkillId")
                        .HasColumnType("bigint");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("ReplacesParent")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("SkillId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.CharacterEvent", b =>
                {
                    b.HasOne("LarpCharacterBuilder3.Models.Character", "Character")
                        .WithMany("CharacterEvents")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LarpCharacterBuilder3.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.CharacterSkill", b =>
                {
                    b.HasOne("LarpCharacterBuilder3.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LarpCharacterBuilder3.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.Event", b =>
                {
                    b.HasOne("LarpCharacterBuilder3.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("LarpCharacterBuilder3.Models.Skill", b =>
                {
                    b.HasOne("LarpCharacterBuilder3.Models.Skill", null)
                        .WithMany("Children")
                        .HasForeignKey("SkillId");
                });
#pragma warning restore 612, 618
        }
    }
}
