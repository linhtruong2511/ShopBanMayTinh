using Microsoft.AspNetCore.Mvc;
using SellComputer.Controllers;
using SellComputer.Data;
using SellComputer.Models.Entities;

namespace SellComputer.Controllers
{
    public class CategoryController : BaseApiController
    {

        public CategoryController(ShopBanMayTinhContext dbContext) : base(dbContext)
        {
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = dbContext.Categories.ToList();
            List<CategoryResponse> categoryResponses = new List<CategoryResponse>();
            // Count total product in category
            foreach (var category in categories)
            {
                var total = dbContext.Computers.Count(c => c.CategoriesId == category.Id);

                CategoryResponse response = new CategoryResponse(category, total);

                categoryResponses.Add(response);
            }

            return Ok(categoryResponses);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] AddCategoryDto categoryDto)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return Ok(category);
        }

    }

}
