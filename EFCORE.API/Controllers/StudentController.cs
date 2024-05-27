using AutoMapper;
using EFCORE.API.Dtos;
using EFCORE.Infrastructure;
using EFCOREAPI.CORE.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using System.Runtime.InteropServices;

namespace EFCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentToCreateDto> _validator;
        private readonly IStudentService _studentService;

        public StudentController(ApplicationContext context, IMapper mapper, IValidator<StudentToCreateDto> validator, IStudentService studentService)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentToCreateDto studentToCreate)
        {
            var validationResult = await _validator.ValidateAsync(studentToCreate);

            if (!validationResult.IsValid)
            {
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            }

            var student = _mapper.Map<Student>(studentToCreate);

            await _studentService.CreateStudent(student);

            return Ok(student);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetStudents();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);

        }


    }
}
