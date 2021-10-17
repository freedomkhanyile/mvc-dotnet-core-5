using MVC.NetCore5.Web.Data.Models;
using MVC.NetCore5.Web.Data.ViewModels;

namespace MVC.NetCore5.Web.Data.Extensions
{
    public static class BookExtensions
    {
#region Book View Model
        public static Book ToEntity(this BookViewModel model)
        {
            return new Book {
                Id = model.Id,
                Name = model.Name,
                Author = model.Author,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }

        public static BookViewModel ToModel(this Book model)
        {
            return new BookViewModel {
                Id = model.Id,
                Name = model.Name,
                Author = model.Author,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }


#endregion



#region Create Book View Model
        public static Book ToEntity(this CreateBookViewModel model)
        {
            return new Book {
                Name = model.Name,
                Author = model.Author,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }
#endregion



#region  Update Book View Model

        public static void UpdateEntity(
            this UpdateBookViewModel model,
            Book entityToUpdate
        )
        {
            entityToUpdate.Name = model.Name;
            entityToUpdate.ISBN = model.ISBN;
            entityToUpdate.Author = model.Author;
            entityToUpdate.Year = model.Year;
        }

        public static UpdateBookViewModel
        ToUpdateViewModel(this BookViewModel model)
        {
            return new UpdateBookViewModel {
                Id = model.Id,
                Name = model.Name,
                Author = model.Author,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }


#endregion
    }
}
