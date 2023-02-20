namespace Common.AdminServices
{
    public interface IAdminService
    {
        Task<List<TDto>> ReadAsync<TDto>(string uri);
        Task<TDto> ReadOneAsync<TDto>(string uri);
        Task CreateAsync<TDto>(string uri, TDto dto);
        Task DeleteAsync<TDto>(string uri);
        Task UpdateAsync<TDto>(string uri, TDto dto);
		Task DeleteAsync<TDto>(string uri, TDto dto);
	}
}