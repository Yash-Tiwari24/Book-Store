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
        public BookController()
        {
            _bookRepository = new BookRepository();

        }

        public ViewResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View(data);

        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<Book> SearchBook(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }



    }
}
