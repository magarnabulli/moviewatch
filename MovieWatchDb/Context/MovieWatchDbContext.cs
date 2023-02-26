
namespace MovieWatchDb.Context
{
	public class MovieWatchDbContext : DbContext
	{

		public MovieWatchDbContext(DbContextOptions<MovieWatchDbContext> options) : base(options) { }
		public virtual DbSet<FilmGenre> FilmGenres { get; set; } = null!;
		public virtual DbSet<SimilarFilms> SimilarFilms { get; set; } = null!;
		public virtual DbSet<Film> Films { get; set; } = null!;
		public virtual DbSet<Director> Directors { get; set; } = null!;
		public virtual DbSet<Genre> Genres { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Director>();
			modelBuilder.Entity<Genre>();
			modelBuilder.Entity<SimilarFilms>().HasKey(ci => new { ci.FilmId, ci.SimilarId });
			modelBuilder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });
			modelBuilder.Entity<Film>(entity =>
			{
				entity.HasOne(f => f.Director).WithMany(d => d.Films).HasForeignKey(f => f.DirectorId);
				entity.HasMany(f => f.Genres).WithMany(p => p.Films).UsingEntity<FilmGenre>().ToTable("FilmGenres");
				entity.HasMany(f => f.SimilarFilms).WithOne(p => p.Similar).HasForeignKey(d => d.SimilarId).OnDelete(DeleteBehavior.ClientSetNull);

			});
			modelBuilder.Entity<Director>().HasData(new Director
			{
				Id= 1,
				Name = "David Lynch"
			}, new Director
			{
				Id=2,
				Name = "Martin Scorsese"
			}, new Director
			{
				Id=3,
				Name= "Steven Soderbergh"
			}, new Director
			{
				Id=4,
				Name="Errol Morris"
			}, new Director
			{
				Id=5,
				Name="Hayao Miyazaki"
			}, new Director
			{
				Id=6,
				Name="Gore Verbinski"
			});
			modelBuilder.Entity<Film>().HasData(new Film
			{
				Id= 1,
				Title="Blue Velvet",
				Released = new DateTime(1986, 04, 13),
				Free=true,
				Description="The discovery of a severed human ear found in a field leads a young man on an investigation related to a beautiful, mysterious nightclub singer and a group of psychopathic criminals who have kidnapped her child.",
				DirectorId=1,
				FilmUrl = "https://www.youtube-nocookie.com/embed/6Q6gQbrEKyU",
				ImgUrl="/images/BlueVelvet.jpg"
			}, new Film
			{
				Id= 2,
				Title="Eraserhead",
				Released = new DateTime(1977, 03, 13),
				Free=false,
				Description="Henry Spencer tries to survive his industrial environment, his angry girlfriend, and the unbearable screams of his newly born mutant child.",
				DirectorId=1,
				FilmUrl = "https://www.youtube.com/embed/7WAzFWu2tVw",
				ImgUrl="/images/Eraserhead.jpg"

			}, new Film
			{
				Id= 3,
				Title="Dune",
				Released = new DateTime(1984, 06, 01),
				Free=false,
				Description="A Duke's son leads desert warriors against the galactic emperor and his father's evil nemesis to free their desert world from the emperor's rule.",
				DirectorId=1,
				FilmUrl = "https://www.youtube.com/embed/KwPTIEWTYEI",
				ImgUrl="/images/Dune.jpg"
			}, new Film
			{
				Id= 4,
				Title="The Wolf of Wallstreet",
				Released = new DateTime(2013, 08, 23),
				Free=true,
				Description="Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
				DirectorId=2,
				FilmUrl = "https://www.youtube.com/embed/iszwuX1AK6A",
				ImgUrl="/images/WolfOfWallStreet.jpg"
			}, new Film
			{
				Id= 5,
				Title="Shutter Island",
				Released = new DateTime(2010, 11, 26),
				Free=false,
				Description="In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.",
				DirectorId=2,
				FilmUrl = "https://www.youtube.com/embed/5iaYLCiq5RM",
				ImgUrl="/images/ShutterIsland.jpg"
			}, new Film
			{
				Id= 6,
				Title="Oceans Eleven",
				Released = new DateTime(2001, 01, 23),
				Free=true,
				Description="Danny Ocean and his ten accomplices plan to rob three Las Vegas casinos simultaneously.",
				DirectorId=3,
				FilmUrl = "https://www.youtube.com/embed/imm6OR605UI",
				ImgUrl="/images/OceansEleven.jpg"
			}, new Film
			{
				Id= 7,
				Title="The Laundromat",
				Released = new DateTime(2019, 04, 15),
				Free=true,
				Description="A widow investigates an insurance fraud, chasing leads to a pair of Panama City law partners exploiting the world's financial system.",
				DirectorId=3,
				FilmUrl = "https://www.youtube.com/embed/wuBRcfe4bSo",
				ImgUrl="/images/TheLaundromat.jpg"
			}, new Film
			{
				Id= 8,
				Title="Fast, Cheap & Out of Control",
				Released = new DateTime(1997, 06, 01),
				Free=false,
				Description="An exploration of the careers of four unrelated professionals: a lion tamer, a robotics expert, a topiary gardener, and a naked mole rat specialist.",
				DirectorId=4,
				FilmUrl = "https://www.youtube.com/embed/n9gFKHAFG94",
				ImgUrl="/images/FastCheapOutOfControl.jpg"
			}, new Film
			{
				Id= 9,
				Title="The Unkown Known",
				Released = new DateTime(2013, 09, 04),
				Free=true,
				Description="Former United States Secretary of Defense, Donald Rumsfeld, discusses his career in Washington D.C. from his days as a congressman in the early 1960s to planning the invasion of Iraq in 2003",
				DirectorId=4,
				FilmUrl = "https://www.youtube.com/embed/J-NSyMTpkYI",
				ImgUrl="/images/UnknownKnown.jpg"
			}, new Film
			{
				Id= 10,
				Title="Spirited Away",
				Released = new DateTime(2001, 03, 18),
				Free=true,
				Description="During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.",
				DirectorId=5,
				FilmUrl = "https://www.youtube.com/embed/ByXuk9QqQkk",
				ImgUrl="/images/SpiritedAway.jpg"
			}, new Film
			{
				Id= 11,
				Title="My Neighbour Totoro",
				Released = new DateTime(1988, 07, 12),
				Free=false,
				Description="When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.",
				DirectorId=5,
				FilmUrl = "https://www.youtube.com/embed/WJC1qciW_3k",
				ImgUrl="/images/MyNeighbourTotoro.jpg"
			}, new Film
			{
				Id= 12,
				Title="Howls Moving Castle",
				Released = new DateTime(1988, 07, 12),
				Free=false,
				Description="When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking castle.",
				DirectorId=5,
				FilmUrl = "https://www.youtube.com/embed/iwROgK94zcM",
				ImgUrl="/images/HowlsMovingCastle.jpg"
			}, new Film
			{
				Id= 14,
				Title="Pirates of the Caribbean: The Curse of the Black Pearl",
				Released = new DateTime(2003, 06, 22),
				Free=false,
				Description="Blacksmith Will Turner teams up with eccentric pirate \"Captain\" Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead.",
				DirectorId=6,
				FilmUrl = "https://www.youtube.com/embed/-9HT0l9HV4c",
				ImgUrl="/images/PiratesOfTheCaribbeanCurseOfThePearl.jpg"
			});
			modelBuilder.Entity<Genre>().HasData(new Genre
			{
				Id=1,
				Name= "Action"
			}, new Genre
			{
				Id=2,
				Name="Mystery"
			}, new Genre
			{
				Id=3,
				Name="Fantasy"
			}, new Genre
			{
				Id=4,
				Name="SciFi"
			}, new Genre
			{
				Id=5,
				Name="Drama"
			}, new Genre
			{
				Id=6,
				Name="Comedy"
			}, new Genre
			{
				Id=7,
				Name="Adventure"
			}, new Genre
			{
				Id=8,
				Name="Horror"
			}, new Genre
			{
				Id=9,
				Name="Thriller"
			}, new Genre
			{
				Id=10,
				Name="Crime"
			}, new Genre
			{
				Id=11,
				Name="Documentary"
			}, new Genre
			{
				Id=12,
				Name="Animation"
			});
			modelBuilder.Entity<FilmGenre>().HasData(new FilmGenre
			{
				FilmId=3,
				GenreId=1
			}, new FilmGenre
			{
				FilmId=1,
				GenreId=2
			}, new FilmGenre
			{
				FilmId=5,
				GenreId=2
			}, new FilmGenre
			{
				FilmId=10,
				GenreId=2
			}, new FilmGenre
			{
				FilmId=2,
				GenreId=3
			}, new FilmGenre
			{
				FilmId=10,
				GenreId=3
			}, new FilmGenre
			{
				FilmId=11,
				GenreId=3
			}, new FilmGenre
			{
				FilmId=3,
				GenreId=4
			}, new FilmGenre
			{
				FilmId=1,
				GenreId=5
			}, new FilmGenre
			{
				FilmId=4,
				GenreId=5
			}, new FilmGenre
			{
				FilmId=7,
				GenreId=5
			}, new FilmGenre
			{
				FilmId=4,
				GenreId=6
			}, new FilmGenre
			{
				FilmId=7,
				GenreId=6
			}, new FilmGenre
			{
				FilmId=11,
				GenreId=6
			}, new FilmGenre
			{
				FilmId=3,
				GenreId=7
			}, new FilmGenre
			{
				FilmId=10,
				GenreId=7
			}, new FilmGenre
			{
				FilmId=2,
				GenreId=8
			}
			, new FilmGenre
			{
				FilmId=1,
				GenreId=9
			}, new FilmGenre
			{
				FilmId=5,
				GenreId=9
			}, new FilmGenre
			{
				FilmId=6,
				GenreId=9
			}, new FilmGenre
			{
				FilmId=1,
				GenreId=10
			}, new FilmGenre
			{
				FilmId=4,
				GenreId=10
			}, new FilmGenre
			{
				FilmId=6,
				GenreId=10
			}, new FilmGenre
			{
				FilmId=7,
				GenreId=10
			}, new FilmGenre
			{
				FilmId=8,
				GenreId=11
			}, new FilmGenre
			{
				FilmId=9,
				GenreId=11
			}, new FilmGenre
			{
				FilmId=10,
				GenreId=12
			}, new FilmGenre
			{
				FilmId=11,
				GenreId=12
			});
			modelBuilder.Entity<SimilarFilms>().HasData(new SimilarFilms
			{
				FilmId=10,
				SimilarId=11
			}, new SimilarFilms
			{
				FilmId =11,
				SimilarId=10
			}, new SimilarFilms
			{
				FilmId =10,
				SimilarId= 12
			}, new SimilarFilms
			{
				FilmId =12,
				SimilarId= 10
			}, new SimilarFilms
			{
				FilmId =12,
				SimilarId= 11
			}, new SimilarFilms
			{
				FilmId =11,
				SimilarId= 12
			}, new SimilarFilms
			{
				FilmId =7,
				SimilarId= 8
			}, new SimilarFilms
			{
				FilmId =8,
				SimilarId= 7
			}, new SimilarFilms
			{
				FilmId =7,
				SimilarId= 9
			}, new SimilarFilms
			{
				FilmId =9,
				SimilarId= 7
			}, new SimilarFilms
			{
				FilmId =8,
				SimilarId= 9
			}, new SimilarFilms
			{
				FilmId =9,
				SimilarId= 8
			});
		}
	}
}
