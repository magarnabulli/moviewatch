
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
			modelBuilder.Entity<FilmGenre>().HasKey(fg => new { fg.GenreId, fg.FilmId});
			modelBuilder.Entity<Film>().HasOne(f => f.Director).WithMany(d => d.Films).HasForeignKey(f => f.DirectorId);
			modelBuilder.Entity<Director>();
			modelBuilder.Entity<Genre>();				
		}
	}
}
