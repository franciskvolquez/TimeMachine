using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeMachine.Models
{
    public class Interaction
    {
        public int Id { get; set; }

        [DisplayName("Tipo de Interacción")]
        public int TypeId { get; set; }

        [DisplayName("Fecha")]
        public DateTime DateTime { get; set; }

        public string UserId { get; set; }

        [MaxLength(500)]
        [DisplayName("Comentario")]
        public string Comment { get; set; }

        //Navigation properties
        public InteractionType Type { get; set; }
        public ApplicationUser User { get; set; }
    }
}