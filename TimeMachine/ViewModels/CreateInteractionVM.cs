using System.Collections.Generic;
using TimeMachine.Models;

namespace TimeMachine.ViewModels
{
    public class CreateInteractionVM
    {
        public Interaction Interaction { get; set; }
        public List<InteractionType> InteractionTypes { get; set; }
    }
}