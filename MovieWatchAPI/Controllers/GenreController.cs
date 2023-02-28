namespace MovieWatchAPI.Controllers
{
	[Route("api/genres")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private readonly IDbService db;
		public GenreController(IDbService db) { this.db = db; }
		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				db.Include<Genre>();
				db.IncludeRef<FilmGenre>();
				List<GenreInfoDto> genres = await db.ReadAsync<Genre, GenreInfoDto>();
		
				return Results.Ok(genres);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet("{id}")]
		public async Task<IResult> Get(int id)
		{
			try
			{
				db.IncludeRef<FilmGenre>();
				db.Include<Film>();
				db.Include<Genre>();
				var genre = await db.ReadOneAsync<Genre, GenreInfoDto>(c => c.Id == id);
			
				return Results.Ok(genre);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IResult> Post([FromBody] CreateGenreDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest();
				var genre = await db.CreateAsync<Genre, CreateGenreDto>(dto);
				if (await db.SaveChangesAsync()==false) { return Results.BadRequest(); }
				return Results.Ok(genre);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] UpdateGenreDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest("No genre has been provided");
				if (!id.Equals(dto.Id)) return Results.BadRequest("Incorrect genre Id");
				var isFound = await db.AnyAsync<Genre>(c => c.Id == dto.Id);
				db.Update<Genre, UpdateGenreDto>(dto.Id, dto);
				var success = await db.SaveChangesAsync();
				if (!success) return Results.BadRequest();
				return Results.NoContent();
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpDelete("{id}")]
		public async Task<IResult> Delete(int id)
		{
			try
			{
				var deleted = await db.DeleteAsync<Genre>(id);
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
