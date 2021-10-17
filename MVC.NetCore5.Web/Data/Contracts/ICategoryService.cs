using System.Collections.Generic;
using System.Collections;
using MVC.NetCore5.Web.Data.ViewModels;

namespace MVC.NetCore5.Web.Data.Services.Contracts
{
    public interface ICategoryService
    {
         CategoryViewModel GetById(int id);

         List<CategoryViewModel> GetAll();

         void CreateCategory(CreateCategoryViewModel model);

         CategoryViewModel UpdateCategory(int id, UpdateCategoryViewModel model);

         void DeleteCategory(int id);
    }
}