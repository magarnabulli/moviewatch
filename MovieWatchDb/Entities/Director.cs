namespace MovieWatchDb.Entities
{
	public class Director : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public virtual ICollection<Film>? Films { get;}	
		
	}
}
