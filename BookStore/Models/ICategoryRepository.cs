using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category AddCategory(Category category);
        void UpdateCategory(int CategoryId, Category category);
        void DeleteCategory(int CategoryId);
    }
}
