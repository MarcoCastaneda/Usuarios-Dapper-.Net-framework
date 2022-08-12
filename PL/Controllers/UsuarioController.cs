using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();

            ML.Result result = BL.Usuario.GetAll();

            usuario.Usuarios = result.Objects;


            return View(usuario);
        }



        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {

            ML.Usuario usuario = new ML.Usuario();
            if (IdUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Usuario.GetById(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = ((ML.Usuario)result.Object);
                }

            }
            return View(usuario);
        }


        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();




            if (usuario.IdUsuario == 0)
            {

                result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {






                    ViewBag.Mensaje = "El Libro se ha agregado";
                }
                else
                {
                    ViewBag.Mensaje = "El Libro no se ha agregado";
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Libro se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al realizar la actualizacion" + result.ErrorMensage;
                }
            }



            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Delete(usuario);

            if (result.Correct)
            {
                ViewBag.Mensaje = "El libro se ha eliminado";
            }
            else
            {
                ViewBag.Mensaje = "error al eliminar";
            }
            return PartialView("modal");
        }






    }
}
