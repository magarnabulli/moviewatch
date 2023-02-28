
namespace MovieWatchDb.Services
{
	public class DbService : IDbService
	{
		private readonly MovieWatchDbContext db;
		private readonly IMapper mapper;

		public DbService(MovieWatchDbContext db, IMapper mapper)
		{
			this.db=db;
			this.mapper=mapper;
		}
		public async Task<List<TEntity>> ReadRefEntityAsync<TEntity>() where TEntity : class, IReference
		{
			var entities = await db.Set<TEntity>().ToListAsync();
			return mapper.Map<List<TEntity>>(entities);
		}
		public async Task<List<TDto>> ReadRefAsync<TEntity, TDto>() where TEntity : class, IReference where TDto : class //read för linktable
		{
			var entities = await db.Set<TEntity>().ToListAsync();
			return mapper.Map<List<TDto>>(entities);
		}
		public async Task<List<TDto>> ReadAsync<TEntity, TDto>() where TEntity : class, IEntity where TDto : class
		{
			var entities = await db.Set<TEntity>().ToListAsync();
			return mapper.Map<List<TDto>>(entities);
		}
		public async Task<List<TDto>> ReadFreeWatchAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
			where TEntity : class, IEntity where TDto : class
		{
			var entities = await db.Set<TEntity>().Where(expression).ToListAsync();
			return mapper.Map<List<TDto>>(entities);
		}
		public async Task<TEntity?> ReadOneAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class, IEntity => await db.Set<TEntity>().SingleOrDefaultAsync(expression);
		public async Task<TEntity?> ReadOneRefAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
	where TEntity : class, IReference => await db.Set<TEntity>().SingleOrDefaultAsync(expression);
		public async Task<TDto> ReadOneAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class, IEntity where TDto : class
		{
			var entity = await ReadOneAsync(expression);
			return mapper.Map<TDto>(entity);
		}
		public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)//VENE
		where TEntity : class, IEntity => await db.Set<TEntity>().AnyAsync(expression);
		public async Task<bool> SaveChangesAsync() => await db.SaveChangesAsync() >=0;
		public async Task<TEntity> CreateAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class
		{
			var entity = mapper.Map<TEntity>(dto);
			await db.Set<TEntity>().AddAsync(entity);
			return entity;
		} //SKAPA TENITY AV DTO
		public async Task<TEntity> CreateRefAsync<TEntity, TDto>(TDto dto) where TEntity : class, IReference where TDto : class
		{
			var entity = mapper.Map<TEntity>(dto);
			await db.Set<TEntity>().AddAsync(entity);
			return entity;
		}//SKAPA TENITY AV LINMINGTABLE DTO
		public void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto : class
		{
			var entity = mapper.Map<TEntity>(dto);
			entity.Id = id;
			db.Set<TEntity>().Update(entity);
		} //UPPDATERAR ENTITY AV DTO
		public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity
		{
			try
			{
				var entity = await ReadOneAsync<TEntity>(e => e.Id == id);
				if (entity == null)
				{
					return false;
				}
				db.Remove(entity);
			}
			catch (Exception)
			{

				throw;
			}
			return true;
		} //TAR BORT ENTITY VIA ID
		public void Include<TEntity>() where TEntity : class, IEntity //INKLUDERA ENTITY SOM ÄRVER AV IENTITY
		{
			var propertyNames = db.Model.FindEntityType(typeof(TEntity)).GetNavigations().Select(e => e.Name);
			if (propertyNames == null) return;
			foreach (var name in propertyNames)
			{
				db.Set<TEntity>().Include(name).Load();
			}
		}
		public void IncludeRef<TEntity>() where TEntity : class //INKLUDERAR ENTITY VIA LINKINGTABLE
		{
			var propertyNames = db.Model.FindEntityType(typeof(TEntity)).GetNavigations().Select(e => e.Name);
			if (propertyNames == null) return;
			foreach (var name in propertyNames)
			{
				db.Set<TEntity>().Include(name).Load();
			}
		}
		public string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity => $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";

		public async Task<bool> DeleteAsync<TEntity>(TEntity linkEntity) where TEntity : class, IReference
		{
			try
			{
				var entity = await ReadOneRefAsync<TEntity>(e => e == linkEntity);
				if (entity == null)
				{
					return false;
				}
				db.Remove(entity);
			}
			catch (Exception)
			{

				throw;
			}
			return true;
		}
	}
}
