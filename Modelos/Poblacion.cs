using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Poblacion")]
    public class Poblacion
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePoblacion { get; set; }

        public int idProvincia { get; set; }

        [ForeignKey("idProvincia")]
        public virtual Provincia Provincia { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}