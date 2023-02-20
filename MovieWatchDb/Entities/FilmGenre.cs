namespace MovieWatchDb.Entities
{
	public class FilmGenre :IReference
	{
		public int FilmId { get; set; }
		public int GenreId { get; set; }
	}
}
