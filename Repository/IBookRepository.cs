using Book_Store.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book_Store.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<List<Book>> GetTopBooksAsync(int count);
        List<Book> SearchBook(string title, string authorName);
        string GetAppName();
    }
}