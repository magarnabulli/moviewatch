
namespace Common.Dtos
{
	public class FilmDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public DateTime Realeased { get; set; }
		public int DirectorId { get; set; }
		public bool Free { get; set; }
		public string Description { get; set; } = null!;
		public string FilmUrl { get; set; } = null!;
		public DirectorDto Director { get; set; } = null!;
		public List<CreateGenreDto> FilmGenres { get; set; } = null!;
		public string ImgUrl { get; set; } = null!;
	}
	public class CreateFilmDto
	{
		public string Title { get; set; } = null!;
		public DateTime Realeased { get; set; }
		public int DirectorId { get; set; }
		public bool Free { get; set; }
		public string Description { get; set; } = null!;
		public string FilmUrl { get; set; } = null!;
		public string ImgUrl { get; set; } = null!;
	}
	public class UpdateFilmDto : CreateFilmDto
	{
		public int Id { get; set; }
	}
}
