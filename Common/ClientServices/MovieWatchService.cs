
using Common.Dtos;

namespace Common.ClientServices
{
	public class MovieWatchService : IMovieWatchService
	{
		private readonly MovieWatchHttpClient Http;
		public MovieWatchService(MovieWatchHttpClient http)
		{
			Http=http;
		}
		
		public async Task<List<FilmInfoDto>> ReadFilmsAsync(bool free)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"films?freeOnly={free}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<FilmInfoDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
		public async Task<List<GenreInfoDto>> ReadGenresAsync()
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync("genres");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<GenreInfoDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
		public async Task<List<FilmGenreDto>> ReadFilmGenresAsync()
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync("filmgenres");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<FilmGenreDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
		public async Task<List<DirectorInfoDto>> ReadDirectorsAsync()
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync("directors");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<List<DirectorInfoDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
		public async Task<FilmInfoDto> ReadFilmAsync(int id)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"films/{id}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<FilmInfoDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
		public async Task<GenreInfoDto> ReadGenreAsync(int id)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"genres/{id}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<GenreInfoDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
		public async Task<DirectorInfoDto> ReadDirectorAsync(int id)
		{
			try
			{
				HttpResponseMessage response = await Http.Client.GetAsync($"directors/{id}");
				response.EnsureSuccessStatusCode();
				var result = JsonSerializer.Deserialize<DirectorInfoDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
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
