using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Data.SqlClient;
using System.Data;
using MVCPlantilla;
using MvcPlantilla.Models;
using MVCPlantilla.Utilerias;



namespace MvcPlantilla.Controllers
{
    public class TemaController : Controller
    {
        //
        // GET: /Tema/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TEMAS_1()
        {

            //obtener todos los Temas
            DataTable dtTema = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarTodo", CommandType.StoredProcedure);

            List<Tema> lsTema = new List<Tema>();

            //convertir el DataTable en List<Tema>

            foreach (DataRow item in dtTema.Rows)
            {
                Tema datosTema = new Tema();

                datosTema.IdTema = int.Parse(item["IdTema"].ToString());
                datosTema.Nombre = item["Nombre"].ToString();

               
                lsTema.Add(datosTema);

            }

            return View(lsTema);

        }

        public ActionResult CreateTema()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CreateTema(Video datosTema)
        {

            //GUARDAR TEMA EN LA BASE DE DATOS

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Nombre",datosTema.Nombre));
            

            BaseHelper.ejecutarSentencia("sp_Tema_Insertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("TEMAS_1");

        }


    }
}
