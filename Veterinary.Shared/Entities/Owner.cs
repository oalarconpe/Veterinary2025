using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public  class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Documento de identidad")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public string Document { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {1} solo permite letras.")]
        public string FirstName { get; set; }



        [Display(Name = "Apellido")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {2} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {2} solo permite letras.")]
        public string LastName { get; set; }


        [Display(Name = "Teléfono fijo")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {3} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {3} solo permite números.")]
        public string FixedPhone { get; set; }

        [Display(Name = "Teléfono Móvil")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {4} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {4} solo permite números.")]
        public string CellPhone { get; set; }


        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {5} es obligatorio.")]
        public string Address { get; set; }



        public string FullName => $"{FirstName} {LastName}";

        [JsonIgnore]

        public ICollection <Agenda> Agendas { get; set; }




    }
}
