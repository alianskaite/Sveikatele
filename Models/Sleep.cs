using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace tp_sveikatele.Models
{
    public class SleepL
    {
        [DisplayName("Pradžia")]
        public DateTime Start { get; set; }
        [DisplayName("Pabaiga")]
        public DateTime End { get; set; }
        [DisplayName("Įvertinimas")]
        public int Rating { get; set; }
        [DisplayName("Trukmė")]
        public int Duration { get; set; }

        public void CountDuration()
        {
			int endHours = End.Hour;
			int endMinutes = End.Minute;
			int startHours = Start.Hour;
			int startMinutes = Start.Minute;
            this.Duration = (endHours*60 + endMinutes) - (startHours*60 + startMinutes);
		}
        public SleepL(DateTime start, DateTime end, int rating)
        {
            this.Start = start;
            this.End = end;
            this.Rating = rating;
            CountDuration();
        }
    }

    public class SleepCE
    {
        public class SleepM
        {
            [DisplayName("Pradžia")]
            DateTime Start { get; set; }
            [DisplayName("Pabaiga")]
            DateTime End { get; set; }
            [DisplayName("Įvertinimas")]
            int Rating { get; set; }
            [DisplayName("Trukmė")]
            int Duration { get; set; }
        }

        public class ListsM
        {
            public IList<SelectListItem> Rating { get; set; }
        }

        public SleepM Sleep { get; set; } = new SleepM();
        public ListsM Lists { get; set; } = new ListsM();
    }

    public class Rating
    {
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
