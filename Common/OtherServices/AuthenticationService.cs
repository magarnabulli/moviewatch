namespace Common.OtherServices
{
	public class AuthenticationService : AuthenticationStateProvider
	{
		private readonly AuthenticationHttpClient http;
		private readonly IStorageService storage;
		private readonly AuthenticationState anonymous;

		public AuthenticationService(AuthenticationHttpClient _http, IStorageService _storage)
		{
			_http= http;
			_storage= storage;
			anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var token = await storage.GetAsync(AuthConstants.TokenName);

			if (string.IsNullOrWhiteSpace(token)) return anonymous;

			http.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
			return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JWTConverter.ParseClaimsFromPayload(token), AuthConstants.AuthType)));
		}
		public async Task<AuthenticatedUserDto?> Login(AuthenticateUserModel userForAuth)
		{
			try
			{
				var user = new LoginUserDto(userForAuth.Email, userForAuth.Password);

				using StringContent jsnContent = new(JsonSerializer.Serialize(user), Encoding.UTF8,"application/json");

				using HttpResponseMessage response = await http.Client.PostAsync("tokens", jsnContent);
				string responseContent = await response.Content.ReadAsStringAsync();

				if(response.StatusCode.Equals(HttpStatusCode.Unauthorized)|| string.IsNullOrWhiteSpace(responseContent))
				{
					var updateTokenUser = new TokenUserDto(userForAuth.Email);

					using StringContent jsonUpdateTokenUser = new(JsonSerializer.Serialize(updateTokenUser), Encoding.UTF8,"application/json");

					using HttpResponseMessage createResponse = await http.Client.PostAsync("tokens/create", jsonUpdateTokenUser);

					createResponse.EnsureSuccessStatusCode();

					using HttpResponseMessage fetchResponse = await http.Client.PostAsync("tokens", jsnContent);
					fetchResponse.EnsureSuccessStatusCode();
					responseContent = await fetchResponse.Content.ReadAsStringAsync();
				}
				var result = JsonSerializer.Deserialize<AuthenticatedUserDto>(responseContent,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				if (result is null) return default;

				await storage.SetAsync(AuthConstants.TokenName, result.AccessToken ?? string.Empty);

				http.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);

				var authenticatedUser = new ClaimsPrincipal(
					new ClaimsIdentity(
						JWTConverter.ParseClaimsFromPayload(result.AccessToken ?? string.Empty),
							AuthConstants.AuthType));

				var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

				NotifyAuthenticationStateChanged(authState);

				return result;
			}
			catch { return default; }
		}

		public async Task Logout()
		{
			await storage.DeleteAsync(AuthConstants.TokenName);

			http.Client.DefaultRequestHeaders.Authorization = null;

			var authState = Task.FromResult(anonymous);

			NotifyAuthenticationStateChanged(authState);
		}

		public async Task<SignUpUserDto?> GetUserFromToken()
		{
			var token = await storage.GetAsync(AuthConstants.TokenName);

			if (string.IsNullOrWhiteSpace(token)) return default;

			return JWTConverter.ParseUserInfoFromPayload(token);
		}

	}
}
