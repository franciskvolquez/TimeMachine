using System;
using System.ComponentModel;

namespace TimeMachine.Model
{

    public class DailyReport
    {

        private DateTime date;

        [DisplayName("Fecha")]
        public String Date { get { return date.ToShortDateString(); } }

        [DisplayName("Horas Trabajadas")]
        public TimeSpan WorkedTime { get; private set; }

        [DisplayName("Validez")]
        public bool IsValid { get; private set; }

        [DisplayName("Mensaje")]
        public string Message { get; set; }

        public DailyReport(DateTime date)
        {
            this.date = date;
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