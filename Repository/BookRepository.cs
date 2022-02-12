using Book_Store.Data;
using Book_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _Context = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext context,IConfiguration configuration)
        {
            _Context = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewBook(Book book)
        {
            var newBook = new Books()
            {
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                Description = book.Description,
                Title = book.Title,
                Language = book.Language,
                TotalPages = book.TotalPages,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = book.CoverImageUrl,
                BookPdfUrl = book.BookPdfUrl


            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in book.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _Context.books.AddAsync(newBook);

            await _Context.SaveChangesAsync();

            return newBook.Id;
        }




        public async Task<List<Book>> GetAllBooks()
        {
            return await _Context.books
                  .Select(book => new Book()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      Language = book.Language,
                      Title = book.Title,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverImageUrl
                  }).ToListAsync();
        }



        public async Task<List<Book>> GetTopBooksAsync(int count)
        {
            return await _Context.books
                  .Select(book => new Book()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      Language = book.Language,
                      Title = book.Title,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverImageUrl
                  }).Take(count).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _Context.books.Where(x => x.Id == id)
                 .Select(book => new Book()
                 {
                     Author = book.Author,
                     Category = book.Category,
                     Description = book.Description,
                     Id = book.Id,

                     Language = book.Language,
                     Title = book.Title,
                     TotalPages = book.TotalPages,
                     CoverImageUrl = book.CoverImageUrl,
                     Gallery = book.bookGallery.Select(g => new GalleryModel()
                     {
                         Id = g.Id,
                         Name = g.Name,
                         URL = g.URL
                     }).ToList(),
                     BookPdfUrl = book.BookPdfUrl
                 }).FirstOrDefaultAsync();
        }

        public List<Book> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();

        }

        private List<Book> DataSource()
        {
            return new List<Book>()
            {
                new Book(){Id=1,Title="MVC",Author="Shivam",Description="This is the Description for MVC book",Category="Programming",Language="English",TotalPages=565},
                new Book(){Id=2,Title="C#",Author="Amit",Description="This is the Description for C# book",Category="Programming",Language="English",TotalPages=1500},
                new Book(){Id=3,Title="Java",Author="Nitin",Description="This is the Description for Java book",Category="Programming",Language="Hindi",TotalPages=715},
                new Book(){Id=4,Title="Php",Author="Ravi",Description="This is the Description for Php book",Category="Programming",Language="English",TotalPages=1034},
                new Book(){Id=5,Title="Dot Net Core",Author="Sharyu",Description="This is the Description for Dot Net Core book",Category="Programming",Language="English",TotalPages=1104},
                   new Book(){Id=6,Title="Azure DevOps",Author="Neha",Description="This is the Description for Azure Dev Ops book",Category="DevOps",Language="English",TotalPages=918},


            };
        }

        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}
