using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("TipoDenuncia")]
    public class TipoDenuncia
    {
        [Key]
        public int id { set; get; }

        [Required]
        [StringLength(100)]
        public string nombre { set; get; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
