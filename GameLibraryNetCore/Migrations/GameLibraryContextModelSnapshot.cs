// <auto-generated />
using GameLibraryNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameLibraryNetCore.Migrations
{
    [DbContext(typeof(GameLibraryContext))]
    partial class GameLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameLibraryNetCore.Models.GameLibrary", b =>
                {
                    b.Property<int>("GameLibraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameSystemID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("GameLibraryID");

                    b.HasIndex("GameSystemID");

                    b.ToTable("GameLibrary");
                });

            modelBuilder.Entity("GameLibraryNetCore.Models.GameSystem", b =>
                {
                    b.Property<int>("GameSystemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("GameSystemID");

                    b.ToTable("GameSystem");
                });

            modelBuilder.Entity("GameLibraryNetCore.Models.GameLibrary", b =>
                {
                    b.HasOne("GameLibraryNetCore.Models.GameSystem", "GameSystems")
                        .WithMany("GameLibrary")
                        .HasForeignKey("GameSystemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
