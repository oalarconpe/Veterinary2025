using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;



using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }




        [Display(Name = "Nombre mascota")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {1} solo permite letras.")]

        public string Name { get; set; }


        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }

        [Display(Name = "Nacido")]
        [Required]
        [DataType(DataType.DateTime)]
        //2025-09-29
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }


        [Display(Name = "Raza")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {1} solo permite letras.")]

        public string Race { get; set; }


        public string  Remarks { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

        public int OwnerId { get; set; }



        [JsonIgnore]
        public PetType PetType { get; set; }

        public int PetTypeId { get; set; }

        [JsonIgnore]

        public ICollection<History> Histories { get; set; }



        [JsonIgnore]


        public ICollection<Agenda> Agendas { get; set; }

       



    }
}
