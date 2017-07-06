using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeMachine.Models
{
    public class Interaction
    {
        public int Id { get; set; }

        [DisplayName("Interaction Type")]
        public int TypeId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        //Navigation properties
        public InteractionType Type { get; set; }
        public ApplicationUser User { get; set; }
    }
}