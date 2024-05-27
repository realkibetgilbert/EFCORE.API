using System.ComponentModel.DataAnnotations;

namespace MODEL
{
    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsRegularStudent { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public StudentDetails StudentDetails { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
