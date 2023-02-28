﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieWatchDb.Context;

#nullable disable

namespace MovieWatchDb.Migrations
{
    [DbContext(typeof(MovieWatchDbContext))]
    [Migration("20230220154324_seed")]
    partial class seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieWatchDb.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "David Lynch"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Steven Soderbergh"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Errol Morris"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hayao Miyazaki"
                        });
                });

            modelBuilder.Entity("MovieWatchDb.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("FilmUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Free")
                        .HasColumnType("bit");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Realeased")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The discovery of a severed human ear found in a field leads a young man on an investigation related to a beautiful, mysterious nightclub singer and a group of psychopathic criminals who have kidnapped her child.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=6Q6gQbrEKyU",
                            Free = true,
                            ImgUrl = "/images/BlueVelvet.jpg",
                            Realeased = new DateTime(1986, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Blue Velvet"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Henry Spencer tries to survive his industrial environment, his angry girlfriend, and the unbearable screams of his newly born mutant child.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=7WAzFWu2tVw",
                            Free = false,
                            ImgUrl = "/images/Eraserhead.jpg",
                            Realeased = new DateTime(1977, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Eraserhead"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A Duke's son leads desert warriors against the galactic emperor and his father's evil nemesis to free their desert world from the emperor's rule.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=KwPTIEWTYEI",
                            Free = false,
                            ImgUrl = "/images/Dune.jpg",
                            Realeased = new DateTime(1984, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Eraserhead"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=iszwuX1AK6A",
                            Free = true,
                            ImgUrl = "/images/WolfOfWallStreet.jpg",
                            Realeased = new DateTime(2013, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Wolf of Wallstreet"
                        },
                        new
                        {
                            Id = 5,
                            Description = "In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=5iaYLCiq5RM",
                            Free = false,
                            ImgUrl = "/images/ShutterIsland.jpg",
                            Realeased = new DateTime(2010, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Shutter Island"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Danny Ocean and his ten accomplices plan to rob three Las Vegas casinos simultaneously.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=imm6OR605UI",
                            Free = true,
                            ImgUrl = "/images/OceansEleven.jpg",
                            Realeased = new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Oceans Eleven"
                        },
                        new
                        {
                            Id = 7,
                            Description = "A widow investigates an insurance fraud, chasing leads to a pair of Panama City law partners exploiting the world's financial system.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=wuBRcfe4bSo",
                            Free = true,
                            ImgUrl = "/images/TheLaundromat.jpg",
                            Realeased = new DateTime(2019, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Laundromat"
                        },
                        new
                        {
                            Id = 8,
                            Description = "An exploration of the careers of four unrelated professionals: a lion tamer, a robotics expert, a topiary gardener, and a naked mole rat specialist.",
                            DirectorId = 4,
                            FilmUrl = "https://www.youtube.com/watch?v=n9gFKHAFG94",
                            Free = false,
                            ImgUrl = "/images/FastCheapOutOfControl.jpg",
                            Realeased = new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fast, Cheap & Out of Control"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Former United States Secretary of Defense, Donald Rumsfeld, discusses his career in Washington D.C. from his days as a congressman in the early 1960s to planning the invasion of Iraq in 2003",
                            DirectorId = 4,
                            FilmUrl = "https://www.youtube.com/watch?v=J-NSyMTpkYI",
                            Free = true,
                            ImgUrl = "/images/UnknownKnown.jpg",
                            Realeased = new DateTime(2013, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Unkown Known"
                        },
                        new
                        {
                            Id = 10,
                            Description = "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.",
                            DirectorId = 5,
                            FilmUrl = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                            Free = true,
                            ImgUrl = "/images/SpiritedAway.jpg",
                            Realeased = new DateTime(2001, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spirited Away"
                        },
                        new
                        {
                            Id = 11,
                            Description = "When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.",
                            DirectorId = 5,
                            FilmUrl = "https://www.youtube.com/watch?v=WJC1qciW_3k",
                            Free = false,
                            ImgUrl = "/images/MyNeighbourTotoro.jpg",
                            Realeased = new DateTime(1988, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "My Neighbour Totoro"
                        });
                });

            modelBuilder.Entity("MovieWatchDb.Entities.FilmGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres", (string)null);

                    b.HasData(
                        new
                        {
                            FilmId = 3,
                            GenreId = 1
                        },
                        new
                        {
                            FilmId = 1,
                            GenreId = 2
                        },
                        new
                        {
                            FilmId = 5,
                            GenreId = 2
                        },
                        new
                        {
                            FilmId = 10,
                            GenreId = 2
                        },
                        new
                        {
                            FilmId = 2,
                            GenreId = 3
                        },
                        new
                        {
                            FilmId = 10,
                            GenreId = 3
                        },
                        new
                        {
                            FilmId = 11,
                            GenreId = 3
                        },
                        new
                        {
                            FilmId = 3,
                            GenreId = 4
                        },
                        new
                        {
                            FilmId = 1,
                            GenreId = 5
                        },
                        new
                        {
                            FilmId = 4,
                            GenreId = 5
                        },
                        new
                        {
                            FilmId = 7,
                            GenreId = 5
                        },
                        new
                        {
                            FilmId = 4,
                            GenreId = 6
                        },
                        new
                        {
                            FilmId = 7,
                            GenreId = 6
                        },
                        new
                        {
                            FilmId = 11,
                            GenreId = 6
                        },
                        new
                        {
                            FilmId = 3,
                            GenreId = 7
                        },
                        new
                        {
                            FilmId = 10,
                            GenreId = 7
                        },
                        new
                        {
                            FilmId = 2,
                            GenreId = 8
                        },
                        new
                        {
                            FilmId = 1,
                            GenreId = 9
                        },
                        new
                        {
                            FilmId = 5,
                            GenreId = 9
                        },
                        new
                        {
                            FilmId = 6,
                            GenreId = 9
                        },
                        new
                        {
                            FilmId = 1,
                            GenreId = 10
                        },
                        new
                        {
                            FilmId = 4,
                            GenreId = 10
                        },
                        new
                        {
                            FilmId = 6,
                            GenreId = 10
                        },
                        new
                        {
                            FilmId = 7,
                            GenreId = 10
                        },
                        new
                        {
                            FilmId = 8,
                            GenreId = 11
                        },
                        new
                        {
                            FilmId = 9,
                            GenreId = 11
                        },
                        new
                        {
                            FilmId = 10,
                            GenreId = 12
                        },
                        new
                        {
                            FilmId = 11,
                            GenreId = 12
                        });
                });

            modelBuilder.Entity("MovieWatchDb.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Documentary"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Animation"
                        });
                });

            modelBuilder.Entity("MovieWatchDb.Entities.Film", b =>
                {
                    b.HasOne("MovieWatchDb.Entities.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MovieWatchDb.Entities.FilmGenre", b =>
                {
                    b.HasOne("MovieWatchDb.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieWatchDb.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieWatchDb.Entities.Director", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
