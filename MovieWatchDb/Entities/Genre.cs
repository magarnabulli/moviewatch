namespace MovieWatchDb.Entities
{
	public class Genre : IEntity
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public virtual ICollection<Film> Films { get; set; } = null!;
	}
}
