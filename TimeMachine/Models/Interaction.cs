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
        public string UserId { get; set; }

        //Navigation properties
        public InteractionType Type { get; set; }
        public ApplicationUser User { get; set; }
    }
}