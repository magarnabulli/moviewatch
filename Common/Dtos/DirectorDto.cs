namespace Common.Dtos
{
	public class DirectorDto //GET Read, id namn och lista av filmer
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
	}
	public class DirectorInfoDto : DirectorDto
	{
		public List<CreateFilmDto>? Films { get; set; }
	}
	public class CreateDirectorDto //för att CREATE post => skriv in namn bara
	{
		public string Name { get; set; } = null!;
	}
	public class UpdateDirectorDto : CreateDirectorDto  //skriver in id på den som ska uppdateras samt nytt namn
	{
		public int Id { get; set; }
	}
}
