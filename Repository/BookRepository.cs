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
                new Book(){Id=1,Title="MVC",Author="Shivam",Description="This is the Description for MVC book"},
                new Book(){Id=2,Title="C#",Author="Amit",Description="This is the Description for C# book"},
                new Book(){Id=3,Title="Java",Author="Nitin",Description="This is the Description for Java book"},
                new Book(){Id=4,Title="Php",Author="Ravi",Description="This is the Description for Php book"},
                new Book(){Id=5,Title="Dot Net Core",Author="Sharyu",Description="This is the Description for Dot Net Core book"},
                   new Book(){Id=6,Title="Azure DevOps",Author="Neha",Description="This is the Description for Azure Dev Ops book"},


            };
        }
    }
}
