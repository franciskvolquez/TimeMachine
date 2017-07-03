using System;

namespace TimeMachine.Models
{
    public class Interaction
    {
        public int Id { get; set; }
        public InteractionType Type { get; set; }
        public DateTime DateTime { get; set; }        
    }
}