using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
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

        [HttpPost]
        public async Task<Category> Post([FromServices] IUseCase<AddCategoryRequest, AddCategoryResponse> useCase,
            [FromBody] AddCategoryAPIRequest request)
        {
            AddCategoryResponse response = await useCase.ExecuteAsync(new AddCategoryRequest()
            {
                Color = request.Color,
                Name = request.Name,
                UserId = HttpContext.User.Identity.Name
            });

            return response.Category;
        }
    }
}
