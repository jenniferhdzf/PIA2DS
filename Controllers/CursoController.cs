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
    public class CursoController : Controller
    {
        //
        // GET: /Curso/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Curso_list()
        {

            //obtener todos los Temas
            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarTodo", CommandType.StoredProcedure);

            List<Curso> lsCurso = new List<Curso>();

            //convertir el DataTable en List<Curso>

            foreach (DataRow item in dtCurso.Rows)
            {
                Curso datosCurso = new Curso();
                datosCurso.IdCurso = int.Parse(item["IdCurso"].ToString());
                datosCurso.Descripcion = item["Descripcion"].ToString();
                datosCurso.IdEmpleado = item["Descripcion"].ToString();



                lsCurso.Add(datosCurso);

            }

            return View(lsCurso);


        }


        public ActionResult CreateCurso()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CreateCurso(Curso datosCurso)
        {

            //GUARDAR TEMA EN LA BASE DE DATOS

            List<SqlParameter> parametros = new List<SqlParameter>();


            parametros.Add(new SqlParameter("@Descripcion", datosCurso.Descripcion));
            parametros.Add(new SqlParameter("@IdCurso", datosCurso.IdEmpleado));


            BaseHelper.ejecutarSentencia("sp_Curso_Insertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Curso_list");

        }


        public ActionResult DetailsCurso(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));



            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso miCurso = new Curso();

            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());

                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = dtCurso.Rows[0]["IdEmpleado"].ToString();

                return View(miCurso);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }

        public ActionResult DeleteCurso(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));



            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso miCurso = new Curso();

            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());

                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = dtCurso.Rows[0]["IdEmpleado"].ToString();

                return View(miCurso);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }

        [HttpPost]

        public ActionResult DeleteCurso(int id, FormCollection frm)
        {
            //obtener info del video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));

            BaseHelper.ejecutarConsulta("sp_Curso_Eliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Curso_list");
        }


        public ActionResult EditCurso(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));



            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso miCurso = new Curso();

            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());

                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = dtCurso.Rows[0]["IdEmpleado"].ToString();

                return View(miCurso);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult EditCurso(int id, Curso datos)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));
            parametros.Add(new SqlParameter("@Descripcion", datos.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datos.IdEmpleado));

            BaseHelper.ejecutarConsulta("sp_Curso_Actualizar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Curso_list");


        }


        //---------------------

    }
}
