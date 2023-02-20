
namespace Common.HttpClients;
public class MovieWatchHttpClient
{
	public HttpClient Client { get; }
	public MovieWatchHttpClient(HttpClient client)
	{
		Client = client;
		Client.BaseAddress = new Uri("https://localhost:6001/api/");
	}
}
