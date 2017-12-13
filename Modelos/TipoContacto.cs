using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("TipoContacto")]
    public class TipoContacto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
