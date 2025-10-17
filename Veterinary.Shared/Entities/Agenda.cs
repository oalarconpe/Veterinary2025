using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public  class Agenda
    {

        public int Id { get; set; }


        [Display(Name = "Fecha cita")]
        [Required]
        [DataType(DataType.DateTime)]
        //2025-09-29
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAppointment { get; set; }


        [Display(Name = "Observacionesy/comentarios")]

        public string Remarks { get; set; }

        [Display(Name = "¿Cita dispinible?")]

        public bool IsValiable { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

        public int OwnerId { get; set; }


        [JsonIgnore]
        public Pet Pet { get; set; }

        public int PetId { get; set; }


    }
}
