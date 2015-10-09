namespace MovieNight.Domain.Entities
{
    public class Submission
    {
        public int SubmissionId { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public int Votes { get; set; }
    }
}
