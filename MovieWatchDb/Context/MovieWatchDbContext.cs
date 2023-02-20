
namespace MovieWatchDb.Context
{
	public class MovieWatchDbContext : DbContext
	{

		public MovieWatchDbContext(DbContextOptions<MovieWatchDbContext> options) : base(options) { }
		public virtual DbSet<FilmGenre> FilmGenres { get; set; } = null!;
		public virtual DbSet<Film> Films { get; set; } = null!;
		public virtual DbSet<Director> Directors { get; set; } = null!;
		public virtual DbSet<Genre> Genres { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });
			modelBuilder.Entity<Film>().HasOne(f => f.Director).WithMany(d => d.Films).HasForeignKey(f => f.DirectorId);
			modelBuilder.Entity<Director>();
			modelBuilder.Entity<Genre>();
			SeedData(modelBuilder);
		}
		private void SeedData(ModelBuilder builder)
		{
			builder.Entity<Film>().HasData(new Film
			{
				Id= 1,
				Title="Blue Velvet",
				Realeased = new DateTime(1986, 04, 13),
				Free=true,
				Description="The discovery of a severed human ear found in a field leads a young man on an investigation related to a beautiful, mysterious nightclub singer and a group of psychopathic criminals who have kidnapped her child.",
				DirectorId=1,
				FilmUrl = "https://www.youtube.com/watch?v=6Q6gQbrEKyU",
				ImgUrl="/images/BlueVelvet.jpg"
			}, new Film
			{
				Id= 2,
				Title="Eraserhead",
				Realeased = new DateTime(1977, 03, 13),
				Free=false,
				Description="Henry Spencer tries to survive his industrial environment, his angry girlfriend, and the unbearable screams of his newly born mutant child.",
				DirectorId=1,
				FilmUrl = "https://www.youtube.com/watch?v=7WAzFWu2tVw",
				ImgUrl="/images/Eraserhead.jpg"
			}, new Film
			{
				Id= 3,
				Title="Eraserhead",
				Realeased = new DateTime(1984, 06, 01),
				Free=false,
				Description="A Duke's son leads desert warriors against the galactic emperor and his father's evil nemesis to free their desert world from the emperor's rule.",
				DirectorId=1,
				FilmUrl = "https://www.youtube.com/watch?v=KwPTIEWTYEI",
				ImgUrl="/images/Dune.jpg"
			}, new Film
			{
				Id= 4,
				Title="The Wolf of Wallstreet",
				Realeased = new DateTime(2013, 08, 23),
				Free=true,
				Description="Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
				DirectorId=2,
				FilmUrl = "https://www.youtube.com/watch?v=iszwuX1AK6A",
				ImgUrl="/images/WolfOfWallStreet.jpg"
			}, new Film
			{
				Id= 5,
				Title="Shutter Island",
				Realeased = new DateTime(2010, 11, 26),
				Free=false,
				Description="In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.",
				DirectorId=2,
				FilmUrl = "https://www.youtube.com/watch?v=5iaYLCiq5RM",
				ImgUrl="/images/ShutterIsland.jpg"
			}, new Film
			{
				Id= 6,
				Title="Oceans Eleven",
				Realeased = new DateTime(2001, 01, 23),
				Free=true,
				Description="Danny Ocean and his ten accomplices plan to rob three Las Vegas casinos simultaneously.",
				DirectorId=3,
				FilmUrl = "https://www.youtube.com/watch?v=imm6OR605UI",
				ImgUrl="/images/OceansEleven.jpg"
			}, new Film
			{
				Id= 7,
				Title="The Laundromat",
				Realeased = new DateTime(2019, 04, 15),
				Free=true,
				Description="A widow investigates an insurance fraud, chasing leads to a pair of Panama City law partners exploiting the world's financial system.",
				DirectorId=3,
				FilmUrl = "https://www.youtube.com/watch?v=wuBRcfe4bSo",
				ImgUrl="/images/TheLaundromat.jpg"
			}, new Film
			{
				Id= 8,
				Title="Fast, Cheap & Out of Control",
				Realeased = new DateTime(1997, 06, 01),
				Free=false,
				Description="An exploration of the careers of four unrelated professionals: a lion tamer, a robotics expert, a topiary gardener, and a naked mole rat specialist.",
				DirectorId=4,
				FilmUrl = "https://www.youtube.com/watch?v=n9gFKHAFG94",
				ImgUrl="/images/FastCheapOutOfControl.jpg"
			}, new Film
			{
				Id= 9,
				Title="The Unkown Known",
				Realeased = new DateTime(2013, 09, 04),
				Free=true,
				Description="Former United States Secretary of Defense, Donald Rumsfeld, discusses his career in Washington D.C. from his days as a congressman in the early 1960s to planning the invasion of Iraq in 2003",
				DirectorId=4,
				FilmUrl = "https://www.youtube.com/watch?v=J-NSyMTpkYI",
				ImgUrl="/images/UnknownKnown.jpg"
			}, new Film
			{
				Id= 10,
				Title="Spirited Away",
				Realeased = new DateTime(2001, 03, 18),
				Free=true,
				Description="During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.",
				DirectorId=5,
				FilmUrl = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
				ImgUrl="/images/SpiritedAway.jpg"
			}, new Film
			{
				Id= 11,
				Title="My Neighbour Totoro",
				Realeased = new DateTime(1988, 07, 12),
				Free=false,
				Description="When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.",
				DirectorId=5,
				FilmUrl = "https://www.youtube.com/watch?v=WJC1qciW_3k",
				ImgUrl="/images/MyNeighbourTotoro.jpg"
			});
			builder.Entity<Director>().HasData(new Director
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
				Id=4, Name="Errol Morris"
			}, new Director
			{
				Id=5,
				Name="Hayao Miyazaki"
			});
			builder.Entity<Genre>().HasData(new Genre
			{
				 Id=1, Name= "Action"
			},new Genre
			{
				Id=2, Name="Mystery"
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
			builder.Entity<FilmGenre>().HasData(new FilmGenre
			{
				 FilmId=3, GenreId=1
			}, new FilmGenre
			{
				FilmId=1, GenreId=2
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
		}
	}
}
