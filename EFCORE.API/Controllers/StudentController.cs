using AutoMapper;
using EFCORE.API.Dtos;
using EFCORE.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;

namespace EFCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public StudentController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentToCreateDto studentToCreateDto)
        {
            var student = _mapper.Map<Student>(studentToCreateDto);

            await _context.students.AddAsync(student);

            return Ok(student);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _context.students.AsNoTracking().Where(s => s.Age > 10).ToList();

            return Ok(students);
        }


    }
}
