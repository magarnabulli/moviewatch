
namespace MovieWatchAPI.Controllers
{
	[Route("api/directors")]
	[ApiController]
	public class DirectorController : ControllerBase
	{
		private readonly IDbService db;
		public DirectorController(IDbService db) { this.db = db; }

		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				db.Include<Director>();
				List<DirectorInfoDto> directors = await db.ReadAsync<Director, DirectorInfoDto>();
				return Results.Ok(directors);
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
				db.Include<Director>();
				db.Include<Film>();
				var director = await db.ReadOneAsync<Director, DirectorInfoDto>(c => c.Id ==id);
				if (director == null) return Results.NotFound("Could not find the director..");
				return Results.Ok(director);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost]
		public async Task<IResult> Post(CreateDirectorDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest();
				var director = await db.CreateAsync<Director, CreateDirectorDto>(dto);
				if (await db.SaveChangesAsync() == false) return Results.BadRequest();
				return Results.Created(db.GetURI<Director>(director), director);

			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] UpdateDirectorDto dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest("No director provided");
				if (!id.Equals(dto.Id)) return Results.BadRequest("Incorrect director Id");
				var isFound = await db.AnyAsync<Director>(i => i.Id == dto.Id);
				if (!isFound) return Results.NotFound("Could not find the director!");
				db.Update<Director, UpdateDirectorDto>(dto.Id, dto);
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
				var deleted = await db.DeleteAsync<Director>(id);
				if (!deleted) return Results.NotFound("Unable to delete the director because it was not found.");
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
