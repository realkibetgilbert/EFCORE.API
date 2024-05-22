using AutoMapper;
using EFCORE.API.Dtos;
using EFCORE.Infrastructure;
using FluentValidation;
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
        private readonly IValidator<StudentToCreateDto> _validator;

        public StudentController(ApplicationContext context, IMapper mapper, IValidator<StudentToCreateDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentToCreateDto studentToCreateDto)
        {
            var validationResult = await _validator.ValidateAsync(studentToCreateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest( Results.ValidationProblem(validationResult.ToDictionary()));
            }

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
