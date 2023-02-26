
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(policy =>
{
	policy.AddPolicy("CorsAllAccessPolicy", opt =>
	opt.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod()
	);
});

builder.Services.AddDbContext<MovieWatchDbContext>(
	options =>
		options.UseSqlServer(
			builder.Configuration.GetConnectionString("MovieWatchConnection")));
builder.Services.AddScoped<IDbService, DbService>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
	cfg.CreateMap<Film, FilmDto>().ReverseMap();
	cfg.CreateMap<Film, FilmInfoDto>().ReverseMap();

	cfg.CreateMap<Film, CreateFilmDto>().ReverseMap();

	cfg.CreateMap<Director, DirectorDto>().ReverseMap();
	cfg.CreateMap<Director, DirectorInfoDto>().ReverseMap();

	cfg.CreateMap<Director, CreateDirectorDto>().ReverseMap();

	cfg.CreateMap<FilmGenre, FilmGenreDto>().ReverseMap().ForMember(t => t.FilmId, opt => opt.MapFrom(t => t.FilmId));
	//här finns eobjekt av filmdto och genre dto för namn?

	cfg.CreateMap<Genre, GenreInfoDto>().ReverseMap();	
	cfg.CreateMap<Genre, GenreDto>().ReverseMap();
	cfg.CreateMap<Genre, CreateGenreDto>().ReverseMap();
	cfg.CreateMap<Genre, UpdateGenreDto>().ReverseMap();
	cfg.CreateMap<SimilarFilms, SimilarFilmsDto>().ReverseMap();
	cfg.CreateMap<SimilarFilms, ManageSimilarFilmDto>().ReverseMap()
	.ForMember(f=>f.Similar, src=> src.Ignore())	
	.ForMember(f=>f.Film, src=> src.Ignore());	
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
