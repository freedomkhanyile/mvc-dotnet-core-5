using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.NetCore5.Web.Data.ViewModels;

namespace MVC.NetCore5.Web.Data.Services.Contracts
{
    public interface IBookService
    {
        BookViewModel GetById(int id);
        IQueryable<BookViewModel> GetAll();

        Task<BookViewModel> CreateBook(CreateBookViewModel model);

        Task<BookViewModel> UpdateBook(int id, UpdateBookViewModel model);

        Task<bool> DeleteBook(int id);
        
    }
}