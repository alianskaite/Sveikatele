namespace tp_sveikatele.Models
{
    public class SleepL
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Rating { get; set; }
        public string Duration => (End - Start).ToString(@"hh\:mm");
        public string RatingStars => new string('★', Rating);
    }
}
