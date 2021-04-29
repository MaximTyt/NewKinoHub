﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewKinoHub.Storage;

namespace NewKinoHub.Migrations
{
    [DbContext(typeof(MvcFilmContext))]
    [Migration("20210429172857_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastPerson", b =>
                {
                    b.Property<int>("CastsId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsId")
                        .HasColumnType("int");

                    b.HasKey("CastsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("CastPerson");
                });

            modelBuilder.Entity("FavoritesMedia", b =>
                {
                    b.Property<int>("FavoritesId")
                        .HasColumnType("int");

                    b.Property<int>("MediasMediaID")
                        .HasColumnType("int");

                    b.HasKey("FavoritesId", "MediasMediaID");

                    b.HasIndex("MediasMediaID");

                    b.ToTable("FavoritesMedia");
                });

            modelBuilder.Entity("GenreMedia", b =>
                {
                    b.Property<int>("GenresGenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediasMediaID")
                        .HasColumnType("int");

                    b.HasKey("GenresGenreId", "MediasMediaID");

                    b.HasIndex("MediasMediaID");

                    b.ToTable("GenreMedia");
                });

            modelBuilder.Entity("MediaViewed", b =>
                {
                    b.Property<int>("MediasMediaID")
                        .HasColumnType("int");

                    b.Property<int>("ViewedsId")
                        .HasColumnType("int");

                    b.HasKey("MediasMediaID", "ViewedsId");

                    b.HasIndex("ViewedsId");

                    b.ToTable("MediaViewed");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Character")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("RoleInFilm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("Casts");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Media", b =>
                {
                    b.Property<int>("MediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumOfEpisodes")
                        .HasColumnType("int");

                    b.Property<int?>("NumOfSeason")
                        .HasColumnType("int");

                    b.Property<string>("Release_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<string>("ScoreKP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoundTrackUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MediaID");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.MediaImages", b =>
                {
                    b.Property<int>("ImagesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagesUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasKey("ImagesID");

                    b.HasIndex("MediaId");

                    b.ToTable("MediaImages");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfBirthday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfDeath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("MediaId");

                    b.HasIndex("UsersId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfBirthday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavoritesId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("ViewedId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("FavoritesId");

                    b.HasIndex("ViewedId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Viewed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vieweds");
                });

            modelBuilder.Entity("CastPerson", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Cast", null)
                        .WithMany()
                        .HasForeignKey("CastsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewKinoHub.Storage.Entity.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FavoritesMedia", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Favorites", null)
                        .WithMany()
                        .HasForeignKey("FavoritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewKinoHub.Storage.Entity.Media", null)
                        .WithMany()
                        .HasForeignKey("MediasMediaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMedia", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewKinoHub.Storage.Entity.Media", null)
                        .WithMany()
                        .HasForeignKey("MediasMediaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediaViewed", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Media", null)
                        .WithMany()
                        .HasForeignKey("MediasMediaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewKinoHub.Storage.Entity.Viewed", null)
                        .WithMany()
                        .HasForeignKey("ViewedsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Cast", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Media", "Media")
                        .WithMany("Casts")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.MediaImages", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Media", "Medias")
                        .WithMany("Images")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medias");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Review", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Media", "Media")
                        .WithMany("Reviews")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewKinoHub.Storage.Entity.Users", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Users", b =>
                {
                    b.HasOne("NewKinoHub.Storage.Entity.Favorites", "Favorites")
                        .WithMany("Users")
                        .HasForeignKey("FavoritesId");

                    b.HasOne("NewKinoHub.Storage.Entity.Viewed", "Viewed")
                        .WithMany("Users")
                        .HasForeignKey("ViewedId");

                    b.Navigation("Favorites");

                    b.Navigation("Viewed");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Favorites", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Media", b =>
                {
                    b.Navigation("Casts");

                    b.Navigation("Images");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Users", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("NewKinoHub.Storage.Entity.Viewed", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
