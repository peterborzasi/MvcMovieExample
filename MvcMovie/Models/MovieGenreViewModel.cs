using Microsoft.AspNetCore.Mvc.Rendering;
using Application;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<MovieResponse> Movies { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}