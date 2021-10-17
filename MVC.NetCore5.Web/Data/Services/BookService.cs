using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.NetCore5.Web.Data.Extensions;
using MVC.NetCore5.Web.Data.Models;
using MVC.NetCore5.Web.Data.Services.Contracts;
using MVC.NetCore5.Web.Data.UnitOfWork;
using MVC.NetCore5.Web.Data.ViewModels;

namespace MVC.NetCore5.Web.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _uow;

        public BookService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<BookViewModel> CreateBook(CreateBookViewModel model)
        {
            var book = model.ToEntity();
            _uow.Add (book);
            await _uow.CommitAsync();
            return book.ToModel();
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToDelete = GetQuery().FirstOrDefault(b => b.Id == id);
            if (bookToDelete == null)
            {
                throw new System.Exception($"Book with id: {id} not found");
            }
            _uow.Remove(bookToDelete.ToEntity());
            await _uow.CommitAsync();
            return true;
        }

        public IQueryable<BookViewModel> GetAll()
        {
            var books = GetQuery();
            return books;
        }

        public BookViewModel GetById(int id)
        {
            var book = GetQuery().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new System.Exception($"Book with id: {id} not found");
            }
            return book;
        }

        public async Task<BookViewModel> UpdateBook(int id, UpdateBookViewModel model)
        {
            var book = GetQuery().FirstOrDefault(b => b.Id == id).ToEntity();
            if (book == null)
            {
                throw new System.Exception($"Book with id: {id} not found");
            }
            
            book.Name = model.Name;
            book.ISBN = model.ISBN;
            book.Author = model.Author;
            book.Year = model.Year; 

            await _uow.CommitAsync();
            
            return book.ToModel();
        }

#region Private methods
        private IQueryable<BookViewModel> GetQuery()
        {
            var q = _uow.Query<Book>();
            var books = q.ToList();
            return books.Select(x => x.ToModel()).AsQueryable();
        }
#endregion
    }
}
