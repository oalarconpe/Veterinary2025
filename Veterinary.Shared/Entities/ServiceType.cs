using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class ServiceType
    {

        public int Id { get; set; }


        [Display(Name = "Tipo de servicio")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {1} solo permite letras.")]
        public string Name { get; set; }


        [JsonIgnore]

        public ICollection <History> Histories { get; set; }

    }
}
