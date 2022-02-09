using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Repository
{
    public class BookRepository
    {
        public List<Book> GetAllBooks()
        {
            return DataSource();
        }

        public Book GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Book> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();

        }

        private List<Book> DataSource()
        {
            return new List<Book>()
            {
                new Book(){Id=1,Title="MVC",Author="Shivam"},
                new Book(){Id=2,Title="C#",Author="Amit"},
                new Book(){Id=3,Title="Java",Author="Nitin"},
                new Book(){Id=4,Title="Php",Author="Ravi"},
                new Book(){Id=5,Title="Dot Net Core",Author="Sharyu"},


            };
        }
    }
}
