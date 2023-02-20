using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Common.AdminServices;
public class AdminService : IAdminService
{
	private readonly MovieWatchHttpClient http;
	public AdminService(MovieWatchHttpClient http)
	{
		this.http = http;
	}
	public async Task<List<TDto>> ReadAsync<TDto>(string uri) //läser in lista av alla objekt
	{
		try
		{
			using HttpResponseMessage response = await http.Client.GetAsync(uri);//"entitet"
			response.EnsureSuccessStatusCode();
			var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<TDto>(); //tom lista skickas och loopen skippas fire bars
		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task<TDto> ReadOneAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await http.Client.GetAsync(uri);//"entitet/id"
			response.EnsureSuccessStatusCode(); //kontrollera om det blir fel, throw körs isf
			var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result; //(Detta blir null om den misslyckas, automatiskt)

		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task CreateAsync<TDto>(string uri, TDto dto)
	{
		try
		{
			using StringContent jsonContent = new(
				JsonSerializer.Serialize(dto),
				Encoding.UTF8,
				"application/json");
			using HttpResponseMessage response = await http.Client.PostAsync(uri, jsonContent);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task UpdateAsync<TDto>(string uri, TDto dto)
	{
		try
		{
			using StringContent jsonContent = new(
			JsonSerializer.Serialize(dto),
			Encoding.UTF8,
			"application/json");
			using HttpResponseMessage response = await http.Client.PutAsync(uri, jsonContent);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task DeleteAsync<TDto>(string uri, TDto dto)
	{
		try
		{
			var request = new HttpRequestMessage(HttpMethod.Delete, uri);
			request.Content= JsonContent.Create(dto);
			using var response = await http.Client.SendAsync(request);
			response.EnsureSuccessStatusCode();

			
		}
		catch (Exception)
		{

			throw;
		}
	}
	public async Task DeleteAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await http.Client.DeleteAsync(uri);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception)
		{

			throw;
		}
	}
}
