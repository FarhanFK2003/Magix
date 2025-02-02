using MagixFinalist.Models;
using MagixFinalist.Repositories;

namespace MagixFinalist.Services
{
    public class MoviesService
    {
        //private readonly IMovieRepository _movieRepository;

        //public MoviesService(IMovieRepository movieRepository)
        //{
        //    _movieRepository = movieRepository;
        //}

        //public IEnumerable<Movie> GetMovies() => _movieRepository.GetAllMovies();

        //public Movie GetMovie(int id) => _movieRepository.GetMovieById(id);

        //public void CreateMovie(Movie movie) => _movieRepository.AddMovie(movie);

        //public void EditMovie(Movie movie) => _movieRepository.UpdateMovie(movie);

        //public void RemoveMovie(int id) => _movieRepository.DeleteMovie(id);

        private readonly IMovieRepository _movieRepository;

        public MoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovie(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }
    }
}
