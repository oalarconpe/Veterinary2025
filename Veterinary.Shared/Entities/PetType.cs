using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class PetType
    {
        public int Id { get; set; }



        [Display(Name = "Tipo de mascota")]
        [MaxLength(20, ErrorMessage = "Este campo solo permite 20 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {1} solo permite letras.")]
        public string Name { get; set; }





       

        public ICollection<Pet> Pets { get; set; }

    }
}
