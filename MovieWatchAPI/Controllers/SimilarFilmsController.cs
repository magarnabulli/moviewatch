using static Common.Dtos.SimilarFilmsDto;

namespace MovieWatchAPI.Controllers
{
	[Route("api/similarfilms")]
	[ApiController]
	public class SimilarFilmsController : ControllerBase
	{
		private readonly IDbService db;
		public SimilarFilmsController(IDbService db) { this.db = db; }
		[HttpPost]
		public async Task<IResult> PostAsync([FromBody] ManageSimilarFilmDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest();
				var similarfilm = await db.CreateAsync<SimilarFilms, ManageSimilarFilmDto>(dto);
				if (await db.SaveChangesAsync() == false) return Results.BadRequest();
				return Results.Created("similarfilms", similarfilm);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				db.Include<Film>();
				db.IncludeRef<SimilarFilms>();
				List<SimilarFilmsDto> similarfilms = await db.ReadRefAsync<SimilarFilms, SimilarFilmsDto>();

				return Results.Ok(similarfilms);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpDelete]
		public async Task<IResult> Delete(ManageSimilarFilmDto dto)
		{
			try
			{
				var similarfilmEntity = new SimilarFilms();
				similarfilmEntity.SimilarId = dto.SimilarId;
				similarfilmEntity.FilmId = dto.FilmId;
				var deleted = await db.DeleteAsync<SimilarFilms>(similarfilmEntity);
				if (!deleted) return Results.NotFound("Unable to delete the movie because it was not found.");
				deleted =await db.SaveChangesAsync();
				if (!deleted) return Results.BadRequest();
				return Results.NoContent();
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
