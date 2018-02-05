using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Denuncia")]
    public class Denuncia
    {
        [Key]
        [Column(Order = 1)]
        public int idUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        public int idEmpresa { get; set; }

        [Key]
        [Column(Order = 3)]
        public int idTipoDenuncia { get; set; }

        [Key]
        [Column(Order = 4)]
        public System.DateTime fecha { get; set; }

        [StringLength(250)]
        public string descripcion { get; set; }

        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("idEmpresa")]
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("idTipoDenuncia")]
        public virtual TipoDenuncia TipoDenuncia { get; set; }
    }
}
