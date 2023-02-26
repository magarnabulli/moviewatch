
namespace MovieWatchDb.Entities
{
	public class SimilarFilms : IReference
	{
		public int FilmId { get; set; }
		public int SimilarId { get; set; }
		[ForeignKey("SimilarId")]
		public virtual Film Similar { get; set; } = null!;
		public virtual Film Film { get; set; } = null!;
	}
}
