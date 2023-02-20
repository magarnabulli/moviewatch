namespace Common.ClientServices
{
	public interface IMovieWatchService
	{
		Task<DirectorDto> ReadDirectorAsync<DirectorDto>(int id);
		Task<List<DirectorDto>> ReadDirectorsAsync();
		Task<FilmDto> ReadFilmAsync<FilmDto>(int id);
		public Task<List<FilmDto>> ReadFilmsAsync(bool free);
		Task<GenreDto> ReadGenreAsync<GenreDto>(int id);
		Task<List<GenreDto>> ReadGenresAsync();
	}
}