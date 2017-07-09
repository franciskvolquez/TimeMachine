using System.Collections.Generic;
using System.Linq;
using TimeMachine.Model;
using TimeMachine.Models;

namespace TimeMachine.Business
{

    public class ReportsService
    {
        public List<DailyReport> GenerateWorkTimeReport(List<Interaction> interactions)
        {
            var report = new List<DailyReport>();

            var group = interactions.GroupBy(i => i.DateTime.Date)
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var day in group)
            {
                var interactionsPerDay = day.ToList();
                var dailyReport = new DailyReport(day.Key);

                //Odd number of interactions
                if (interactionsPerDay.Count % 2 != 0)
                {
                    dailyReport.Message = "El día tiene número impar de interacciones.";
                    report.Add(dailyReport);
                    continue;
                }

                var lastInInteraction = interactionsPerDay.First();

                //First interaction of day is of type "Out"
                if (lastInInteraction.Type.Action == InteractionTypeActions.Out)
                {
                    dailyReport.Message = "La primera interaccion del día no puede ser de salida.";
                    report.Add(dailyReport);
                    continue;
                }

                for (int i = 1; i < interactionsPerDay.Count; i++)
                {
                    var interaction = interactionsPerDay[i];

                    //Consecutive interactions of same action type. 
                    if (interaction.Type.Action == lastInInteraction.Type.Action)
                    {
                        dailyReport.Message = "Se registraron dos interacciones consecutivas de la misma acción.";
                        report.Add(dailyReport);
                        break;
                    }

                    if (interaction.Type.Action == InteractionTypeActions.Out)
                    {
                        var elapsedTime = interaction.DateTime.Subtract(lastInInteraction.DateTime);
                        dailyReport.AddHours(elapsedTime);
                    }

                    lastInInteraction = interaction;
                }

                dailyReport.SetAsValid();
                report.Add(dailyReport);
            }

            return report;
        }

    }
}