namespace MODEL
{
    public class Evaluation
    {
        public long Id { get; set; }
        public int Grade { get; set; }
        public string AdditionalExplanation { get; set; }
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}
