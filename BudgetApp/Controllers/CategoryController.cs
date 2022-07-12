using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
using BudgetApp.Apllication.Category.AddDefaultCategories;
using BudgetApp.Apllication.Category.DeleteCategory;
using BudgetApp.Apllication.Category.EditCategory;
using BudgetApp.Apllication.Category.GetCategories;
using BudgetApp.Apllication.Category.GetCategory;
using BudgetApp.Domain.Category;
using BudgetApp.Requests;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<Category>> GetCategories([FromServices] IUseCase<GetCategoriesRequest, GetCategoriesResponse> useCase)
        {
            GetCategoriesResponse response = await useCase.ExecuteAsync(new GetCategoriesRequest()
            {
                UserId = HttpContext.User.Identity.Name
            });

            return response.Categories;
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Category> GetCategory([FromServices] IUseCase<GetCategoryRequest, GetCategoryResponse> useCase,
            [FromRoute] Guid id)
        {
            GetCategoryResponse response = await useCase.ExecuteAsync(new GetCategoryRequest()
            {
                UserId = HttpContext.User.Identity.Name,
                Id = id
            });

            return response.Category;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<Category> AddCategory([FromServices] IUseCase<AddCategoryRequest, AddCategoryResponse> useCase,
            [FromBody] ModifyCategoryAPIRequest request)
        {
            AddCategoryResponse response = await useCase.ExecuteAsync(new AddCategoryRequest()
            {
                Color = request.Color.ToUpper(),
                Name = request.Name,
                UserId = HttpContext.User.Identity.Name
            });

            return response.Category;
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<Category> EditCategory([FromServices] IUseCase<EditCategoryRequest, EditCategoryResponse> useCase,
            [FromBody] ModifyCategoryAPIRequest request,
            [FromRoute] Guid id)
        {
            EditCategoryResponse response = await useCase.ExecuteAsync(new EditCategoryRequest()
            {
                Id = id,
                Color = request.Color.ToUpper(),
                Name = request.Name,
                UserId = HttpContext.User.Identity.Name
            });

            return response.Category;
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task DeleteCategory([FromServices] IUseCase<DeleteCategoryRequest, DeleteCategoryResponse> useCase,
            [FromRoute] Guid id)
        {
            DeleteCategoryResponse response = await useCase.ExecuteAsync(new DeleteCategoryRequest()
            {
                UserId = HttpContext.User.Identity.Name,
                Id = id
            });
        }
        
        [HttpPost]
        [Route("default")]
        public async Task AddDefaultCategories([FromServices] IUseCase<AddDefaultCategoriesRequest, AddDefaultCategoriesResponse> useCase,
            [FromBody] AddDefaultCategoriesAPIRequest request,
            [FromServices] IConfiguration configuration)
        {
            if (configuration.GetSection("Auth0").GetValue<string>("Secret") != request.Secret)
            {
                throw new UnauthorizedAccessException();
            }
            
            await useCase.ExecuteAsync(new AddDefaultCategoriesRequest()
            {
                UserId = request.UserId
            });
        }
    }
}
