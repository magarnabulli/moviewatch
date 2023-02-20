
namespace Common.ClientServices
{
	public class MovieWatchService : IMovieWatchService
	{
		private readonly MovieWatchHttpClient Http;
		public MovieWatchService(MovieWatchHttpClient http)
		{
			Http=http;
		}
		public async Task<List<FilmDto>> ReadFilmsAsync(bool free)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"films?Free={free}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<FilmDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive= true,
				});
				return result ?? new();
			}
			catch
			{
				return new();
			}
		}
		public async Task<List<GenreDto>> ReadGenresAsync()
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync("genres");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<GenreDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive= true,
				});
				return result ?? new();
			}
			catch
			{
				return new();
			}
		}
		public async Task<List<DirectorDto>> ReadDirectorsAsync()
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync("directors");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<DirectorDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive= true,
				});
				return result ?? new();
			}
			catch
			{
				return new();
			}
		}
		public async Task<FilmDto> ReadFilmAsync<FilmDto>(int id)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"films/{id}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<FilmDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive= true,
				});
				return result;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<GenreDto> ReadGenreAsync<GenreDto>(int id)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"genres/{id}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<GenreDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive= true,
				});
				return result;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<DirectorDto> ReadDirectorAsync<DirectorDto>(int id)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"directors/{id}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<DirectorDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive= true,
				});
				return result;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
