using EFCOREAPI.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MODEL;

namespace EFCORE.Infrastructure.Sqlserverimplementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationContext _context;

        private readonly IMemoryCache _cache;

        public StudentService(ApplicationContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<Student> CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();

            //invalidate cache.....for products as new product is added.....................
            string cacheKey = "students";

            _cache.Remove(cacheKey);

            return student;

        }

        public async Task<Student> GetStudentById(long id)
        {
            string cacheKey = $"product{id}";

            if (!_cache.TryGetValue(cacheKey, out Student? student))
            {
                //cache failed..... fetch from db............
                student = await _context.Students.FindAsync(id);
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                    .SetPriority(CacheItemPriority.Normal);

                _cache.Set(cacheKey, student, cacheOptions);

            }
            return student;

        }

        public async Task<List<Student>> GetStudents()
        {
            var cacheKey = "products";
            if (!_cache.TryGetValue(cacheKey, out List<Student>? students))
            {
                //cach mis...
                students = await _context.Students.ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                .SetPriority(CacheItemPriority.NeverRemove)
                .SetSize(2048);
                _cache.Set(cacheKey, students, cacheOptions);

            }
            return students;
        }
    }
}
