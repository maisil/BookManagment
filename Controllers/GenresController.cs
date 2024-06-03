using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookManagment.Data;
using BookManagment.Models;
using System.ComponentModel.Design;
using BookManagment.Services.Interfaces;

namespace BookManagment.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: Genres
        public IActionResult Index()
        {
            return View(_genreService.GetAll());
        }

        

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
               _genreService.Add(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _genreService.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id,[Bind("Name")] Genre genre)
        {
           
             
            if (ModelState.IsValid)
            {
                var updatedGenre = _genreService.GetById(id);
                updatedGenre.Name = genre.Name;
               _genreService.Update(updatedGenre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

          
            var genre = (_genreService.GetById(id));
            if(genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound(ModelState);
            }
            var genre = _genreService.GetById(id);
            if (genre != null)
            {
                _genreService.Delete(id);
            }

           
            return RedirectToAction(nameof(Index));
        }

       
    }
}
