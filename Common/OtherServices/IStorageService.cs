namespace Common.OtherServices
{
	public  interface IStorageService
	{
		Task<string> GetAsync(string key);
		Task SetAsync(string key, string value);
		Task DeleteAsync(string key);
	}
}
