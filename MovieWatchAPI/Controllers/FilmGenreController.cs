namespace MovieWatchAPI.Controllers
{
	[Route("api/filmgenres")]
	[ApiController]
	public class FilmGenreController : ControllerBase
	{
		private readonly IDbService db;
		public FilmGenreController(IDbService db) { this.db = db; }
		[HttpPost]
		public async Task<IResult> PostAsync([FromBody] FilmGenreDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest();
				var filmgenre = await db.CreateAsync<FilmGenre, FilmGenreDto>(dto);
				if (await db.SaveChangesAsync() == false) return Results.BadRequest();
				return Results.Created("filmgenres", filmgenre);
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
				List<FilmGenreDto> filmGenres = await db.ReadRefAsync<FilmGenre, FilmGenreDto>();

				return Results.Ok(filmGenres);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpDelete]
		public async Task<IResult> Delete(FilmGenreDto dto)
		{
			try
			{
				var filmGenreEntity = new FilmGenre();
				filmGenreEntity.GenreId = dto.GenreId;
				filmGenreEntity.FilmId = dto.FilmId;
				var deleted = await db.DeleteAsync<FilmGenre>(filmGenreEntity);
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
