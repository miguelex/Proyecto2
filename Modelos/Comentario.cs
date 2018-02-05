using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Comentario")]
    public class Comentario
    {
        [Key]
        [Column(Order = 1)]
        public int idUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        public int idEmpresa { get; set; }

        [Key]
        [Column(Order = 3)]
        public System.DateTime fecha { get; set; }

        [StringLength(250)]
        public string comentario { get; set; }

        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("idEmpresa")]
        public virtual Empresa Empresa { get; set; }

    }
}
