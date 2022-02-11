using Book_Store.Data;
using Book_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _Context=null;

        public BookRepository(BookStoreContext context)
        {
            _Context = context;
        }

        public async Task<int> AddNewBook(Book book) 
        {
            var newBook = new Books()
            {
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                Description = book.Description,
                Title = book.Title,
                Language=book.Language,
                TotalPages = book.TotalPages,
                UpdatedOn = DateTime.UtcNow

            };
          await  _Context.books.AddAsync(newBook);
           await _Context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<Books>> GetAllBooks()
        {
            var books = new List<Books>();
            var allbooks = await _Context.books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new Books()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages=book.TotalPages


                    });

                }
            }
            return books;
        }

        public async Task<Books> GetBookById(int id)
        {
            var book = await _Context.books.FindAsync(id);
          if(book!=null)
            {
                var bookDetails = new Books()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }

        public List<Book> SearchBook(string title,string authorName)
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
    }
}
