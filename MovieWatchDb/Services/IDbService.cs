namespace MovieWatchDb.Services
{
	public interface IDbService
	{
		public Task<List<TDto>> ReadRefAsync<TEntity, TDto>() where TEntity : class, IReference where TDto : class;
		public Task<List<TDto>> ReadAsync<TEntity, TDto>() where TEntity : class, IEntity where TDto : class;
		public Task<List<TDto>> ReadFreeWatchAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class;
		public Task<TEntity> ReadOneAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
		public Task<TDto> ReadOneAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class;
		public Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
		public Task<TEntity> CreateAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class;
		public Task<bool> SaveChangesAsync();
		void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto : class;
		public Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
		void Include<TEntity>() where TEntity : class, IEntity; 
		void IncludeRef<TEntity>() where TEntity : class;
		public string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
		Task<TEntity> CreateRefAsync<TEntity, TDto>(TDto dto)
			where TEntity : class, IReference
			where TDto : class;
		public Task<bool> DeleteAsync<TEntity>(TEntity linkEntity) where TEntity : class, IReference;
		void Update<TEntity>(TEntity linkEntity) where TEntity : class, IReference;
	}	
}
