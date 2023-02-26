namespace MovieWatchDb.Services
{
	public interface IDbService
	{
		Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
		Task<TEntity> CreateAsync<TEntity, TDto>(TDto dto)
			where TEntity : class
			where TDto : class;
		Task<TEntity> CreateRefAsync<TEntity, TDto>(TDto dto)
			where TEntity : class, IReference
			where TDto : class;
		Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
		Task<bool> DeleteAsync<TEntity>(TEntity linkEntity) where TEntity : class, IReference;
		string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
		void Include<TEntity>() where TEntity : class, IEntity;
		void IncludeRef<TEntity>() where TEntity : class;
		Task<List<TDto>> ReadAsync<TEntity, TDto>()
			where TEntity : class, IEntity
			where TDto : class;
		Task<List<TDto>> ReadFreeWatchAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
			where TEntity : class, IEntity
			where TDto : class;
		Task<TDto> ReadOneAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
			where TEntity : class, IEntity
			where TDto : class;
		Task<TEntity?> ReadOneAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
		Task<TEntity?> ReadOneRefAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IReference;
		Task<List<TDto>> ReadRefAsync<TEntity, TDto>()
			where TEntity : class, IReference
			where TDto : class;
		Task<List<TEntity>> ReadRefEntityAsync<TEntity>() where TEntity : class, IReference;
		Task<bool> SaveChangesAsync();
		void Update<TEntity, TDto>(int id, TDto dto)
			where TEntity : class, IEntity
			where TDto : class;
	}
}