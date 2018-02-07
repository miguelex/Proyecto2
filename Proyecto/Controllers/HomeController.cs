using Modelos;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto.Controllers
{
    public class HomeController : BaseController
    {

        private Correo miCorreo = new Correo();
        private Usuario usuario = new Usuario();

        // GET: Home
        public ActionResult Index()
        {
            // Devuelvo vista Index
            return View();
        }


        public ActionResult About()
        {
            // LLamada a página Acerca de ...
            return View();
        }

        public ActionResult FAQ()
        {
            // LLamada a página FAQ
            return View();
        }

        public ActionResult Contacto()
        {
            // LLamada a formulario de contacto
            ViewBag.listadoAsunto = miCorreo.ObtenerListado(); // Obtengo listado de posibles motivos para contactar
            return View();
        }

        public ActionResult Enviar(String Correo, String Asunto, String Cuerpo)
        {
            // Metodo que enviará un correo a administración
            try
            {
                Correo Cr = new Correo();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = Cr.ObtenerAsunto(Asunto);

                mnsj.To.Add(new MailAddress("tfguhuwebmaster@gmail.com"));

                mnsj.From = new MailAddress(Correo);

                mnsj.Body = "Mensaje enviado por " + Correo + "\n" + Cuerpo; // Invluyo la dirección de quien envia el correo

                /* Enviar */
                Cr.MandarCorreo(mnsj);

                Success("El correo se ha enviado correctamente", true);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Danger("Algo salio mal. " + ex, true);
                return RedirectToAction("Contacto", "Home");
            }
        }

        public ActionResult Login()
        {
            // Devuelvo la vista con el formulario de Login
            return View();
        }

        public ActionResult Entrar(String nick, String clave)
        {
            // Lógica que resuelve el login
            Usuario user;

            user = usuario.Login(nick, clave); // Comrpuebo que hay un usuario con el par nick,clave correcto. Si es asi lo recuepro para usar sus datos

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.nick, false);
                //Almacenamos en una variable de sesion aquellos datos que pueden ser usados mientras estemos conectados a la aplicacion
                Session["usuario"] = user.nombre;
                Session["id"] = user.id;
                Session["rol"] = user.administrador;
                return RedirectToAction("Index", "Home"); // Volvemos a la página de Index ya logeado y con nuevas opciones
            }
            else
            {
                Danger("Datos de acceso incorrectos ", true);
                return RedirectToAction("Login", "Home"); // Retorno a la página de login indicando que algún dato no era correcto
            }
        }

        public ActionResult Logout()
        {
            //Lógica que resuelve el log out
            FormsAuthentication.SignOut(); //Eliminamos cookie de autentificacion
            Session.Abandon(); //Eliminamos variable de sesion
            return RedirectToAction("Index", "Home"); // Vuelvo al Index
        }
    }
}