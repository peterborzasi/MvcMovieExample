using Application.Contexts;
using Application.Contexts.Movies;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Migrations;
using MvcMovie.Models;
using Persistence;

namespace MvcMovie.Controllers;

public class MoviesController : Controller
{
    private readonly GetAllMoviesContext _getAllMoviesContext;

    public MoviesController(GetAllMoviesContext getAllMoviesContext)
    {
        _getAllMoviesContext = getAllMoviesContext;
    }

    // GET: Movies
    public async Task<IActionResult> Index(string movieGenre, string searchString)
    {
        var movies = await _getAllMoviesContext.Execute(movieGenre, searchString);

        var movieGenreVM = new MovieGenreViewModel
        {
            Genres = new SelectList(movies.Genres),
            Movies = movies.Movies.ToList()
        };

        return View(movieGenreVM);
    }

    // GET: Movies/Details/5

    public async Task<IActionResult> Details(long? id, [FromServices] GetMovieDetailsContext context)
    {
        if (id == null)
        {
            return NotFound();
        }

        GetMovieDetailsResponse movie = await context.Execute(id.Value);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }


    // GET: Movies/Create

    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/linkId/3434.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateMovieRequest request, [FromServices] CreateMovieContext context)
    {
        if (ModelState.IsValid)
        {
            await context.Execute(request);

            return RedirectToAction(nameof(Index));
        }
        return View(request);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(long? id, [FromServices] EditMovieContext context)
    {
        if (!id.HasValue) return NotFound();

        EditMovieRequest movie = await context.GetMovieDetailsForEdit(id.Value);
        //GetMovieForEditResponse movie = await context.GetMovieForEdit(id.Value);

        EditMovieRequest requestForEdit = new EditMovieRequest
        {
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            Genre = movie.Genre,
            Rating = movie.Rating,
        };
        return View(requestForEdit);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [FromForm] EditMovieRequest movie, [FromServices] EditMovieContext context)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await context.Execute(id, movie);

            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(long? id, [FromServices] DeleteMovieContext context)
    {
        if (!id.HasValue) return NotFound();

        DeleteMovieRequest movie = await context.GetMovieDetailsForDelete(id.Value);

        DeleteMovieRequest requestForDelete = new DeleteMovieRequest
        {
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            Genre = movie.Genre,
            Rating = movie.Rating,
        };
        return View(requestForDelete);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id, [FromForm] DeleteMovieRequest movie, [FromServices] DeleteMovieContext context)
    {
        //var movie = context.GetMovieDetailsForDelete(id.Value);

        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await context.Execute(id, movie);

            return RedirectToAction(nameof(Index));
        }
        return View(movie);




        // if (_context.Movie == null)
        // {
        //     return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        // }
        // var movie = await _context.Movie.FindAsync(id);
        // if (movie != null)
        // {
        //     _context.Movie.Remove(movie);
        // }
        //
        // await _context.SaveChangesAsync();

        //return RedirectToAction(nameof(Index));
    }
}
