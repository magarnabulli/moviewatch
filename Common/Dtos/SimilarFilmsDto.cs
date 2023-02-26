namespace Common.Dtos
{
	public class SimilarFilmsDto
	{
		public int FilmId { get; set; }
		public int SimilarId { get; set; }
		public FilmDto? Similar { get; set; }
		public FilmDto? Film { get; set; }

	}
	public class ManageSimilarFilmDto
	{
		public int FilmId { get; set; }
		public int SimilarId { get; set; }
	}
}
