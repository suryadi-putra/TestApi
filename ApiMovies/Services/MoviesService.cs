using ApiMovies.Data;
using ApiMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiMovies.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        int limitrecords = 100;
        public List<Movies> GetAllMovies() => _context.movies.OrderBy(s=>s.movies).Take(limitrecords).ToList();



        public Movies GetMoviesById(string movies)
        {
  
            var _movies = _context.movies.Where(n => n.movies.StartsWith(movies)).Select(movies => new Movies()
            {
                movies = movies.movies,
                year= movies.year,
                genre=movies.genre,
                rating= movies.rating,
                one_line = movies.one_line,
                stars = movies.stars,
                votes = movies.votes,
                runtime = movies.runtime,
                gross = movies.gross,

            }).FirstOrDefault();

            return _movies;
        }

        public void AddMovies(Movies movies)
        {
            var _movies = new Movies()
            {
                movies = movies.movies,
                year = movies.year,
                genre=movies.genre,
                rating = movies.rating,
                one_line = movies.one_line,
                stars = movies.stars,
                votes = movies.votes,
                runtime = movies.runtime,
                gross = movies.gross,
            };
            _context.movies.Add(_movies);
            _context.SaveChanges();
        }

        public Movies UpdateMovies(string mov, Movies movies)
        {
            var _movies = _context.movies.FirstOrDefault(n => n.movies == mov);
            if (_movies != null)
            {
                _movies.year = movies.year;
                _movies.rating = movies.rating;
                _movies.genre = movies.genre;
                _movies.one_line = movies.one_line;
                _movies.stars = movies.stars;
                _movies.votes = movies.votes;
                _movies.runtime = movies.runtime;
                _movies.gross = movies.gross;
         
                _context.SaveChanges();
            }

            return _movies;
        }


        public void DeleteMovies(string movies)
        {
            var _movies = _context.movies.FirstOrDefault(n => n.movies == movies);
            if (_movies != null)
            {
                _context.movies.Remove(_movies);
                _context.SaveChanges();
            }
        }

    }
}
