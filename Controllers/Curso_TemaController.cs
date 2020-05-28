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
    public class Curso_TemaController : Controller
    {
        //
        // GET: /Curso_Tema/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CT_list()
        {

            //obtener todos los Temas
            DataTable dtCursoTema = BaseHelper.ejecutarConsulta("sp_Curso_Tema_ConsultarTodo", CommandType.StoredProcedure);

            List<Curso_Tema> lsCursoTema = new List<Curso_Tema>();

            //convertir el DataTable en List<Curso_Tema>

            foreach (DataRow item in dtCursoTema.Rows)
            {
                Curso_Tema datosCursoTema = new Curso_Tema();
                datosCursoTema.IdCT = int.Parse(item["IdCT"].ToString());
                datosCursoTema.IdCurso = int.Parse(item["IdCurso"].ToString());
                datosCursoTema.IdTema = int.Parse(item["IdTema"].ToString());

               
                lsCursoTema.Add(datosCursoTema);

            }

            return View(lsCursoTema);




        }








    }
}
