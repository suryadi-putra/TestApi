using ApiMovies.Models;
using ApiMovies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService _moviesService;
        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllMovies()
        {
            var allMovies = _moviesService.GetAllMovies();
            return Ok(allMovies);
        }


        [HttpGet("get-movie-by-name/{movies}")]
        public IActionResult GetBookById(string movies)
        {
            var _movies = _moviesService.GetMoviesById(movies);
            return Ok(_movies);
        }

        [HttpPost("add-movie")]
        public IActionResult AddMovies([FromBody] Movies movies)
        {
            _moviesService.AddMovies(movies);
            return Ok();
        }

        [HttpPut("update-movie-by-name/{movies}")]
        public IActionResult UpdateMovies(string movies, [FromBody] Movies item)
        {
            var updatedmovie = _moviesService.UpdateMovies(movies, item);
            return Ok(updatedmovie);
        }

        [HttpDelete("delete-movies/{movies}")]
        public IActionResult DeleteMovies(string movies)
        {
            _moviesService.DeleteMovies(movies);
            return Ok();
        }

    }
}
