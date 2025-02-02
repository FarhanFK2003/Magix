using Dapper;
using System.Data;
using MagixFinalist.Models;
using Microsoft.Data.SqlClient;

namespace MagixFinalist.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        //private readonly List<Movie> _movies;

        //public MovieRepository()
        //{
        //    // Initialize with some sample data
        //    _movies = new List<Movie>
        //{

        //    new Movie { Id = 1, Name = "Interstellar", Description = "A team of explorers travel through a wormhole in space.", Price = 14.99, ImgPath = "images/interstellar.jpg" },
        //    new Movie { Id = 2, Name = "The Dark Knight", Description = "Batman faces the Joker in Gotham City.", Price = 13.99, ImgPath = "images/darkknight.jpg" },
        //    new Movie { Id = 3, Name = "Avatar", Description = "A paraplegic marine on an alien planet.", Price = 15.99, ImgPath = "images/avatar.jpg" },
        //    new Movie { Id = 4, Name = "Inception", Price = 12.99, Description = "A skilled thief is given a chance to erase his past crimes.", ImgPath = "/images/inception.jpg" },
        //    new Movie { Id = 5, Name = "The Matrix", Price = 10.99, Description = "A hacker discovers the nature of reality.", ImgPath = "/images/matrix.jpg" },
        //};
        //}

        //public IEnumerable<Movie> GetAllMovies() => _movies;

        //public Movie GetMovieById(int id) => _movies.FirstOrDefault(m => m.Id == id);

        //public void AddMovie(Movie movie)
        //{
        //    movie.Id = _movies.Max(m => m.Id) + 1; // Auto-increment ID for simplicity
        //    _movies.Add(movie);
        //}

        //public void UpdateMovie(Movie movie)
        //{
        //    var existingMovie = GetMovieById(movie.Id);
        //    if (existingMovie != null)
        //    {
        //        existingMovie.Name = movie.Name;
        //        existingMovie.Price = movie.Price;
        //        existingMovie.Description = movie.Description;
        //        existingMovie.ImgPath = movie.ImgPath;
        //    }
        //}

        //public void DeleteMovie(int id)
        //{
        //    var movie = GetMovieById(id);
        //    if (movie != null)
        //    {
        //        _movies.Remove(movie);
        //    }
        //}

        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MagixDB;Integrated Security=True;";

        public MovieRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Creates and returns a new SQL connection object
        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Movie";
                return connection.Query<Movie>(query);
            }
        }

        public Movie GetMovieById(int id)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Movie WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Movie>(query, new { Id = id });
            }
        }

        public void AddMovie(Movie movie)
        {
            using (var connection = CreateConnection())
            {
                string query = "INSERT INTO Movie (Name, Price, Description, ImgPath) VALUES (@Name, @Price, @Description, @ImgPath)";
                connection.Execute(query, movie);
            }
        }

        public void UpdateMovie(Movie movie)
        {
            using (var connection = CreateConnection())
            {
                string query = "UPDATE Movie SET Name = @Name, Price = @Price, Description = @Description, ImgPath = @ImgPath WHERE Id = @Id";
                connection.Execute(query, movie);
            }
        }

        public void DeleteMovie(int id)
        {
            using (var connection = CreateConnection())
            {
                string query = "DELETE FROM Movie WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}