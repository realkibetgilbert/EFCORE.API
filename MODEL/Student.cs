namespace MODEL
{
    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsRegularStudent { get; set; }

        public StudentDetails StudentDetails { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
