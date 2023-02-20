

using Common.ClientServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<MovieWatchHttpClient>(client => client.BaseAddress = new Uri("https://localhost:6001/api/")); 
builder.Services.AddScoped<IMovieWatchService, MovieWatchService>();
await builder.Build().RunAsync();
