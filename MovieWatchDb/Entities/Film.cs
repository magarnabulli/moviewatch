namespace MovieWatchDb.Entities
{
	public class Film : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public DateTime Released { get; set; }
		[ForeignKey("DirectorId")]
		public int DirectorId { get; set; }
		public bool Free { get; set; }
		public string Description { get; set; } = null!;
		public string FilmUrl { get; set; } = null!;
		public string ImgUrl { get; set; } = null!;
		public virtual Director Director { get; } = null!;
		public virtual ICollection<SimilarFilms>? SimilarFilms { get; set; }
		public virtual ICollection<Genre>? Genres { get; set; }
	}
}
