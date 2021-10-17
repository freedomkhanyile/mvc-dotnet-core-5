using MVC.NetCore5.Web.Data.ViewModels;
using MVC.NetCore5.Web.Data.Models;

namespace MVC.NetCore5.Web.Data.Extensions
{
    public static class BookExtensions
    {
        public static Book ToEntity(this BookViewModel model)
        {
            return new Book {
                // Id = model.Id,
                Author = model.Author,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }

        public static BookViewModel ToModel(this Book model)
        {
            return new BookViewModel {
                Id = model.Id,
                Author = model.Author,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }
    }
}
