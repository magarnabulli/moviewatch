namespace Common.Dtos
{
	public class FilmDto //update i admin?
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public DateTime Released { get; set; }
		public int DirectorId { get; set; }
		public bool Free { get; set; }
		public string Description { get; set; } = null!;
		public string FilmUrl { get; set; } = null!;
		public string ImgUrl { get; set; } = null!;
		public DirectorDto Director { get; set; } = null!;
	}
	public class FilmInfoDto : FilmDto //Get film 
	{
		public List<SimilarFilmsDto>? SimilarFilms { get; set; }
		public List<GenreDto>? Genres { get; set; }
	}
	public class CreateFilmDto
	{
		public string Title { get; set; } = null!;
		public DateTime Released { get; set; }
		public int DirectorId { get; set; }
		public bool Free { get; set; }
		public string Description { get; set; } = null!;
		public string FilmUrl { get; set; } = null!;
		public string ImgUrl { get; set; } = null!;
	}
	public class UpdateFilmDto : CreateFilmDto //update i cruddar o controller
	{
		public int Id { get; set;}
	}
}
