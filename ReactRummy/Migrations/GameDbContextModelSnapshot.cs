﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactRummy.Data;

namespace ReactRummy.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactRummy.Models.Card", b =>
                {
                    b.Property<int>("Suit");

                    b.Property<int>("Value");

                    b.Property<int>("LocationID");

                    b.HasKey("Suit", "Value");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("ReactRummy.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<int>("Winner");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ReactRummy.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameID");

                    b.Property<int>("Hand");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ReactRummy.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameID");

                    b.Property<int>("HandID");

                    b.Property<int>("LaydownID");

                    b.Property<int>("Score");

                    b.Property<string>("User");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ReactRummy.Models.Player", b =>
                {
                    b.HasOne("ReactRummy.Models.Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
