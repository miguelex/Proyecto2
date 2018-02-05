using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Propietario")]
    public class Propietario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Debe introducir su nombre")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string nick { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string clave { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string email { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public bool bloqueado { get; set; }

        public bool activado { get; set; }

        public bool reseteado { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
