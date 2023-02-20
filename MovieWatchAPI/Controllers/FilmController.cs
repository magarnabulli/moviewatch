
using MovieWatchDb.Entities;

namespace MovieWatchAPI.Controllers
{
	[Route("api/films")]
	[ApiController]
	public class FilmController : ControllerBase
	{
		private readonly IDbService db;
		public FilmController(IDbService db) { this.db = db; }
		[HttpGet]
		public async Task<IResult> Get(bool freeOnly)
		{
			try
			{
				db.Include<Film>();
				List<FilmDto> films = freeOnly ?
					await db.ReadFreeWatchAsync<Film, FilmDto>(c => c.Free == freeOnly) :
					await db.ReadAsync<Film, FilmDto>();
				var filmsgenre = await db.ReadRefAsync<FilmGenre, FilmGenreDto>();
				foreach (var film in films)
				{
					foreach (var genre in filmsgenre)
					{
						if (genre.FilmId.Equals(film.Id))
						{
							film.FilmGenres.Add(await db.ReadOneAsync<Genre, CreateGenreDto>(g => g.Id == genre.GenreId));
						}
					}
				}
				return Results.Ok(films);
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
				db.Include<Genre>();
				db.Include<Director>();
				var film = await db.ReadOneAsync<Film, FilmDto>(c => c.Id == id);
				var filmsgenre = await db.ReadRefAsync<FilmGenre, FilmGenreDto>();
				foreach (var filmGenre in filmsgenre)
				{
					if (filmGenre.FilmId.Equals(film.Id))
					{
						film.FilmGenres.Add(await db.ReadOneAsync<Genre, CreateGenreDto>(g => g.Id == filmGenre.GenreId));
					}
				}
				return Results.Ok(film);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IResult> Post([FromBody] CreateFilmDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest();
				var film = await db.CreateAsync<Film, CreateFilmDto>(dto);
				if (await db.SaveChangesAsync() == false) return Results.BadRequest();
				return Results.Ok(film);
				//return Results.Created(db.GetURI<(boolVar), boolvar
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] UpdateFilmDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest("No movie provided");
				if (!id.Equals(dto.Id)) return Results.BadRequest("Incorrect movie Id");
				var isFound = await db.AnyAsync<Film>(i => i.Id == dto.Id);
				if (!isFound) return Results.NotFound("Could not find the movie!");
				db.Update<Film, UpdateFilmDto>(dto.Id, dto);
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
				var deleted = await db.DeleteAsync<Film>(id);
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
