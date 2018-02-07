using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Usuario")]
    public class Usuario
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

        public bool bloqueado { get; set; }

        public bool administrador { get; set; }

        public int idPoblacion { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }

        public DateTime creado { get; set; }

        [ForeignKey("idPoblacion")]
        public virtual Poblacion Poblacion { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

        public virtual ICollection<Valoracion> Valoracion { get; set; }

        public Usuario Login(String nick, String clave)
        {
            // Método que atiende el login
            var usuario = new Usuario();
            Auxiliar aux = new Auxiliar();

            usuario = Buscar(nick); // Buscamos al usaurio
            if (usuario != null)
            {
                // Si hemos recibido un usuario (no es nulo)
                if (usuario.clave == aux.claveToMD5(clave))
                {
                    return usuario; // Login correcto. Devolvemos el usuario al controlador
                }
            }
            return null;
        }

        public Usuario Buscar(String correo)
        {
            // Método que nos va a permitir buscar a un usuario por su nick o por su correo
            var usuario = new Usuario();
            Auxiliar aux = new Auxiliar();
            try
            {
                using (var context = new DBTFGContext())
                {
                    // EN priemr lugar debemos averigur si el nick pasaso es en relaidad un nick o un correo. 
                    if (aux.IsValidEmail(correo))
                        // Es un correo, asi que buscaremos al usuario cuyo correo coincida con el pasado por parametro
                        usuario = context.Usuario.FirstOrDefault(u => u.email == correo);
                    else
                        // Es un nick, asi que buscamos por ese campo
                        usuario = context.Usuario.FirstOrDefault(u => u.nick == correo);
                    if (usuario != null)
                    {
                        // Si tenemos a un usuario, lo devolvemos
                        return usuario;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }


}
