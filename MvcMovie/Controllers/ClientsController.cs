using Application.Contexts;
using Application.Contexts.Clients;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Migrations;
using MvcMovie.Models;
using Persistence;

namespace MvcMovie.Controllers;

public class ClientsController : Controller
{
    private readonly GetAllClientsContext _getAllClientsContext;

    public ClientsController(GetAllClientsContext getAllClientsContext)
    {
        _getAllClientsContext = getAllClientsContext;
    }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
        var clients = await _getAllClientsContext.Execute();

        var clientsVM = new ClientViewModel
        {
            Clients = clients.Clients.ToList()
        };

        return View(clientsVM);
    }

    // GET: Movies/Details/5

    public async Task<IActionResult> Details(long? id, [FromServices] GetClientDetailsContext context)
    {
        if (id == null)
        {
            return NotFound();
        }

        GetClientDetailsResponse client = await context.Execute(id.Value);

        if (client == null)
        {
            return NotFound();
        }

        return View(client);
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
    public async Task<IActionResult> Create([FromForm] CreateClientRequest request, [FromServices] CreateClientContext context)
    {
        if (ModelState.IsValid)
        {
            await context.Execute(request);

            return RedirectToAction(nameof(Index));
        }
        return View(request);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(long? id, [FromServices] EditClientContext context)
    {
        if (!id.HasValue) return NotFound();

        EditClientRequest client = await context.GetClientDetailsForEdit(id.Value);

        EditClientRequest requestForEdit = new EditClientRequest
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Address = client.Address,
        };
        return View(requestForEdit);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [FromForm] EditClientRequest client, [FromServices] EditClientContext context)
    {
        if (id != client.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await context.Execute(id, client);

            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(long? id, [FromServices] DeleteClientContext context)
    {
        if (!id.HasValue) return NotFound();

        DeleteClientRequest client = await context.GetClientDetailsForDelete(id.Value);

        DeleteClientRequest requestForDelete = new DeleteClientRequest
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Address = client.Address,
        };
        return View(requestForDelete);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id, [FromServices] DeleteClientContext context)
    {
        var client = context.GetClientDetailsForDelete(id.Value);

        if (id != client.Id)
        {
            return NotFound();
        }

        //if (ModelState.IsValid)
        //{
        //    await context.Execute(id, movie);

        //    return RedirectToAction(nameof(Index));
        //}
        //return View(movie);




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

        return RedirectToAction(nameof(Index));
    }
}
