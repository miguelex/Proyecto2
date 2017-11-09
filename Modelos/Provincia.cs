using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Provincia")]
    public class Provincia
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreProvincia { get; set; }

        public virtual ICollection<Poblacion> Poblacion { get; set; }
    }
}
