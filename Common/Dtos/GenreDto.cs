namespace Common.Dtos
{
	public class GenreDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }		
	}
	public class CreateGenreDto
	{
		public string Name { get; set; }
	}
	public class UpdateGenreDto : CreateGenreDto 
	{
		public int Id { get; set; }
	}
	public class GenreInfoDto : GenreDto
	{
		public List<CreateFilmDto> Films { get; set; } = null!;
	}

}
