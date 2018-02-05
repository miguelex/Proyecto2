using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Valoracion")]
    public class Valoracion
    {
        [Key]
        [Column(Order = 1)]
        public int idUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        public int idEmpresa { get; set; }

        [Key]
        [Column(Order = 3)]
        public int idFacilitador { get; set; }

        [Key]
        [Column(Order = 4)]
        public System.DateTime fecha { get; set; }

        [Required]
        public int valor { get; set; }

        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("idEmpresa")]
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("idFacilitador")]
        public virtual Facilitador Facilitador { get; set; }
    }
}
