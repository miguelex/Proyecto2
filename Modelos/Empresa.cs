using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        public float latitud { get; set; }

        [Required]
        public float longitud { get; set; }

        public int idPropietario { get; set; }

        public int idPoblacion { get; set; }

        public bool bloqueado { get; set; }

        [ForeignKey("idPoblacion")]
        public virtual Poblacion Poblacion { get; set; }

        [ForeignKey("idPropietario")]
        public virtual Propietario Propietario { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
        
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        
        public virtual ICollection<Valoracion> Valoracion { get; set; }
        
        //public virtual ICollection<Usuario> Usuario { get; set; }
        
        public virtual ICollection<Facilitador> Facilitador { get; set; }
        
        public virtual ICollection<TipoEmpresa> TipoEmpresa { get; set; }
    }
}
