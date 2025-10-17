using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
       
        public string Description { get; set; }



        [Display(Name = "Fecha")]
        [Required]
        [DataType(DataType.DateTime)]
        //2025-09-29
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Display(Name = "Fecha local")]
       
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();


        [Display(Name = "Observacionesy/comentarios")]

        public string Remarks { get; set; }


        [JsonIgnore]
        public Pet Pet { get; set; }
        public int PetId { get; set; }


        [JsonIgnore]
        public ServiceType ServiceType { get; set; }

        public int ServicetypeId { get; set; }









    }
}
