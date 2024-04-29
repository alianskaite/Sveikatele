using tp_sveikatele.Models;

namespace tp_sveikatele.Repositories
{
    public class SleepRepo
    {
        public static List<SleepL> List()
        {
            List<SleepL> list = new List<SleepL>();
            DateTime start = new DateTime(2000, 10, 29, 18, 2, 12);
            DateTime end = DateTime.Now;
            int quality = 1;
            SleepL sleep = new SleepL(start, end, quality);
            list.Add(sleep);
            return list;
        }
    }

}