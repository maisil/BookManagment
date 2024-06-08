using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookManagment.Data;
using BookManagment.Models;
using BookManagment.Services.Interfaces;

namespace BookManagment.Controllers
{
    public class BooksController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        public BooksController(IBookService bookService, IAuthorService authorService, IGenreService genreService,IPublisherService publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
            _publisherService = publisherService;
        }

        // GET: Books
        public  IActionResult Index()
        {
            var bookList = _bookService.GetAll();
            return View( bookList);
        }

        // GET: Books/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_authorService.GetAll(), "Id", "Id");
            ViewData["GenreId"] = new SelectList(_genreService.GetAll(), "Id", "Id");
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,GenreId,Isbn,PublishDate,Language,Edition,BookCost,NoOfPages,Description,ActualStock,CurrentStock,ImgLink,AuthorId,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(book);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_authorService.GetAll(), "Id", "Id", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_genreService.GetAll(), "Id", "Id", book.GenreId);
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAll(), "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_authorService.GetAll(), "Id", "Id", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_genreService.GetAll(), "Id", "Id", book.GenreId);
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAll(), "Id", "Id", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Title,GenreId,Isbn,PublishDate,Language,Edition,BookCost,NoOfPages,Description,ActualStock,CurrentStock,ImgLink,AuthorId,PublisherId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.Update(book);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_authorService.GetAll(), "Id", "Id", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_genreService.GetAll(), "Id", "Id", book.GenreId);
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAll(), "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetById(id);
           
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var book = _bookService.GetById(id);
            if (book != null)
            {
               _bookService.Delete(id);
            }

           
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(string id)
        {
            var book = _bookService.GetById(id);
            return book != null ;
        }
    }
}
