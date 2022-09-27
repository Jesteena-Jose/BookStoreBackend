using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository repository;
        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int CategoryId)
        {
            repository.DeleteCategory(CategoryId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int CategoryId,Category category)
        {
            repository.UpdateCategory(CategoryId, category);
            return Ok();
        }
    }
}
