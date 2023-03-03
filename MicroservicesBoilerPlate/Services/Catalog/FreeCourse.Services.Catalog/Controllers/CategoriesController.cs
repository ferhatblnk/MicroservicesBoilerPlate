using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> GetAll() => CreateActionResultInstance(await _categoryService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) => CreateActionResultInstance(await _categoryService.GetByIdAsync(id));

        public async Task<IActionResult> Create(CategoryDto categoryDto) => CreateActionResultInstance(await _categoryService.CreateAsync(categoryDto));
    }
}



