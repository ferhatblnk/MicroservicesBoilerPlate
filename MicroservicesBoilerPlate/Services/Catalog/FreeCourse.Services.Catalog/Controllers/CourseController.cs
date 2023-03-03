using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) => CreateActionResultInstance(await _courseService.GetByIdAsync(id));

        public async Task<IActionResult> GetAllAsync() => CreateActionResultInstance(await _courseService.GetAllAsync());

        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId) => CreateActionResultInstance(await _courseService.GetAllByUserId(userId));

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto) => CreateActionResultInstance(await _courseService.CreateAsync(courseCreateDto));

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto) => CreateActionResultInstance(await _courseService.UpdateAsync(courseUpdateDto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) => CreateActionResultInstance(await _courseService.DeleteAsync(id));
    }  
}
