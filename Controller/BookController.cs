using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;

        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data =await _bookRepository.GetAllBooks();
            return View(data);

        }

        [Route("book-details/{id}",Name="BookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
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
        public async Task<IActionResult> AddNewBook(Book book)
        {
            if(ModelState.IsValid)
            {
                if(book.CoverPhoto!=null)
                {
                    string folder = "books/cover";
                   book.CoverImageUrl= await UploadImage(folder,book.CoverPhoto);
                }

                if (book.GalleryFile != null)
                {
                    string folder = "books/gallery";
                    book.Gallery = new List<GalleryModel>();

                    foreach (var file in book.GalleryFile)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)

                        };
                        book.Gallery.Add(gallery);
                }
                }

                if (book.BookPdf != null)
                {
                    string folder = "books/pdf";
                    book.BookPdfUrl = await UploadImage(folder, book.BookPdf);
                }


                int id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
             
            }
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;
            return View();

        }

        private async Task<string> UploadImage(string folderPath,IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        

            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            return "/" + folderPath;
        }
    }
}
