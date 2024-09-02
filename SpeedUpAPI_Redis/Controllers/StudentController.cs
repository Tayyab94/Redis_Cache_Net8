using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedUpAPI_Redis.Models;
using SpeedUpAPI_Redis.Services.CachingServices;

namespace SpeedUpAPI_Redis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ABContext _context;
        private readonly IRedisService _redisService;

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, ABContext context,
            IRedisService redisService)
        {
            _logger = logger;
            this._context = context;
            this._redisService = redisService;
        }

        [HttpGet(Name = "GetallStudents")]
        public async Task<IEnumerable<Student>> Get()
        {

            // if we want to cache the data for the sepecifc user, then we can do this in different ways.
            // one of them which i am using is to pass the user Id in the request-header

            var userId = Request.Headers["userId"];
            var cacheKey = $"car_{userId}";
            var data = _redisService.GetData<IEnumerable<Student>>(cacheKey);
            if (data is not null)
                return data;

            data = await _context.Students.ToListAsync();
            _redisService.SetData(cacheKey, data);
            return data;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student model)
        {
            _context.Students.Add(new Student { Name = model.Name });
            await
                _context.SaveChangesAsync();

            return RedirectToAction(nameof(Get));
        }
    }
}
