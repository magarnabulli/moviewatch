namespace Common.ClientServices
{
	public interface IMovieWatchService
	{
		Task<DirectorInfoDto> ReadDirectorAsync(int id);
		Task<List<DirectorInfoDto>> ReadDirectorsAsync();
		Task<FilmInfoDto> ReadFilmAsync(int id);
		Task<List<FilmGenreDto>> ReadFilmGenresAsync();
		public Task<List<FilmInfoDto>> ReadFilmsAsync(bool free);
		Task<GenreInfoDto> ReadGenreAsync(int id);
		Task<List<GenreInfoDto>> ReadGenresAsync();
	}
}