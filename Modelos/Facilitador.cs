using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Facilitador")]
    public class Facilitador
    {
        [Key]
        public int id { set; get; }

        [Required]
        [StringLength(100)]
        public string nombre { set; get; }

        public virtual ICollection<Valoracion> Valoracion { get; set; }
       
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
