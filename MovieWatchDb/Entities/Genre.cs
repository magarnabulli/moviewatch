namespace MovieWatchDb.Entities
{
	public class Genre : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//collection navigation property
		public virtual ICollection<Film> FilmGenres { get; set; } = null!;

	}

}
