using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREAPI.CORE.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateStudent(Student student);
        Task<Student> GetStudentById(long id);
        Task<List<Student>> GetStudents();
    }
}
