using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
using BudgetApp.Apllication.Category.EditCategory;
using BudgetApp.Apllication.Category.GetCategories;
using BudgetApp.Domain.Category;
using BudgetApp.Requests;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Category>> AddCategory([FromServices] IUseCase<GetCategoriesRequest, GetCategoriesResponse> useCase)
        {
            GetCategoriesResponse response = await useCase.ExecuteAsync(new GetCategoriesRequest()
            {
                UserId = HttpContext.User.Identity.Name
            });

            return response.Categories;
        }
        
        [HttpPost]
        public async Task<Category> AddCategory([FromServices] IUseCase<AddCategoryRequest, AddCategoryResponse> useCase,
            [FromBody] ModifyCategoryAPIRequest request)
        {
            AddCategoryResponse response = await useCase.ExecuteAsync(new AddCategoryRequest()
            {
                Color = request.Color,
                Name = request.Name,
                UserId = HttpContext.User.Identity.Name
            });

            return response.Category;
        }
        
        [HttpPut("{id}")]
        public async Task<Category> EditCategory([FromServices] IUseCase<EditCategoryRequest, EditCategoryResponse> useCase,
            [FromBody] ModifyCategoryAPIRequest request,
            [FromRoute] Guid id)
        {
            EditCategoryResponse response = await useCase.ExecuteAsync(new EditCategoryRequest()
            {
                Id = id,
                Color = request.Color,
                Name = request.Name,
                UserId = HttpContext.User.Identity.Name
            });

            return response.Category;
        }
    }
}
