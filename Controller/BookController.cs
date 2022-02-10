using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }

        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);

        }

        [Route("book-details/{id}",Name="BookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            dynamic data = new System.Dynamic.ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "Nitish";
            return View(data);
        }

        public List<Book> SearchBook(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess=false,int bookId=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(Books book)
        {
          int id= await _bookRepository.AddNewBook(book);
            if(id>0)
            {
                return RedirectToAction(nameof(AddNewBook),new {isSuccess=true,bookId=id});
            }
            return View();
        }


    }
}
