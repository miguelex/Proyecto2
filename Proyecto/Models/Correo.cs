using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Models
{
    public class Correo
    {
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
        DBTFGContext db = new DBTFGContext();

        public Correo()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo 
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential("tfguhuwebmaster@gmail.com", "miguerafa");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            // Método con el que mandamos el correo
            server.Send(mensaje);
        }

        public List<SelectListItem> ObtenerListado()
        {
            // Método que devuelve el listado de opciones para el campo asunto del formulario de contacto. 

            List<TipoContacto> Tipos = new List<TipoContacto>();
            List<SelectListItem> ListaTipos = new List<SelectListItem>();

            Tipos = db.TipoContacto.ToList();
            foreach (TipoContacto tp in Tipos)
            {
                ListaTipos.Add(new SelectListItem()
                {
                    Text = tp.nombre,
                    Value = tp.id.ToString()
                });

            }
            return ListaTipos;
        }

        public String ObtenerAsunto(string id)
        {
            // Este método nos permite recuperar la cadena de texto que ira en el asunto del mensaje desde la BD
            TipoContacto miContacto = db.TipoContacto.First(i => i.id.ToString() == id);
            if (miContacto != null)
            {
                return miContacto.nombre;
            }
            else
            {
                return null;
            }
        }
    }
}
