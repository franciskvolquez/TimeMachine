using System;
using System.ComponentModel;

namespace TimeMachine.Models
{
    public class Interaction
    {
        public int Id { get; set; }

        [DisplayName("Interaction Type")]
        public int TypeId { get; set; }
        public DateTime DateTime { get; set; }

        //Navigation properties
        public InteractionType Type { get; set; }

    }
}