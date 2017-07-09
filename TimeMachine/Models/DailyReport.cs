using System;

namespace TimeMachine.Model
{

    public class DailyReport
    {
        public DateTime Date { get; private set; }
        public TimeSpan WorkedTime { get; private set; }
        public bool IsValid { get; private set; }
        public string Message { get; set; }

        public DailyReport(DateTime date)
        {
            Date = date;
            IsValid = false;
            WorkedTime = new TimeSpan(0, 0, 0);
        }

        public void SetAsValid()
        {
            IsValid = true;
        }

        public void AddHours(TimeSpan elapsed)
        {
            WorkedTime += elapsed;
        }
    }
}