
namespace Common.Dtos
{
	public class CreateGenreDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class GenreDto : CreateGenreDto//för admin
	{
		public List<CreateFilmDto> FilmGenres { get; set; } = null!;
	}
	public class UpdateGenreDto : CreateGenreDto //för admin
	{
		public int Id { get; set; } //ta fram med id
	}

}
