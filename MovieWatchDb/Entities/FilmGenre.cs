namespace MovieWatchDb.Entities
{
	public class FilmGenre :IReference
	{
		public int FilmId { get; set; }
		public int GenreId { get; set; }
		[ForeignKey("FilmId")]
		public Film Film { get; set; } = null!;
		[ForeignKey("GenreId")]
		public Genre Genre { get; set; } = null!;
	}
}
