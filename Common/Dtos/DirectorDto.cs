
namespace Common.Dtos
{
	public class DirectorDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public List<CreateFilmDto>? Films { get; set; }
	}
	public class CreateDirectorDto
	{
		public string? Name { get; set; }
	}
	public class UpdateDirectorDto :CreateDirectorDto
	{
		public int Id { get; set; }
	}
}
