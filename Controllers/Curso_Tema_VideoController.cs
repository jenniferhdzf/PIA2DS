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
    public class Curso_Tema_VideoController : Controller
    {
        //
        // GET: /Curso_Tema_Video/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CTVideo_list()
        {

            //obtener todos los Temas
            DataTable dtCursoTemaVideo = BaseHelper.ejecutarConsulta("sp_CTV_ConsultarTodo", CommandType.StoredProcedure);

            List<Curso_Tema_Video> lsCursoTemaVideo = new List<Curso_Tema_Video>();

            //convertir el DataTable en List<Curso_Tema_Video>

            foreach (DataRow item in dtCursoTemaVideo.Rows)
            {
                Curso_Tema_Video datosCursoTemaVideo = new Curso_Tema_Video();
                
                datosCursoTemaVideo.IdCTV = int.Parse(item["IdCTV"].ToString());
                datosCursoTemaVideo.IdCT = int.Parse(item["IdCT"].ToString());
                datosCursoTemaVideo.IdVideo = int.Parse(item["IdVideo"].ToString());




                lsCursoTemaVideo.Add(datosCursoTemaVideo);

            }

            return View(lsCursoTemaVideo);


        }


        public ActionResult CreateCursoTemaVideo()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CreateCursoTemaVideo(Curso_Tema_Video datosCursoTemaVideo)
        {

            //GUARDAR TEMA EN LA BASE DE DATOS

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter ("@IdCT",datosCursoTemaVideo.IdCT));
            parametros.Add(new SqlParameter("@IdVideo", datosCursoTemaVideo.IdVideo));
            parametros.Add(new SqlParameter("@IdCTV", datosCursoTemaVideo.IdCTV));



            BaseHelper.ejecutarSentencia("sp_CTV_Insertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("CTVideo_list");

        }

        public ActionResult DetailsCursoTemaVideo(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", id));



            DataTable dtCursoTemaVideo = BaseHelper.ejecutarConsulta("sp_CTV_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso_Tema_Video miCursoTemaVideo = new Curso_Tema_Video();

            if (dtCursoTemaVideo.Rows.Count > 0)
            {


                miCursoTemaVideo.IdCTV = int.Parse(dtCursoTemaVideo.Rows [0]["IdCTV"].ToString());
                miCursoTemaVideo.IdCT = int.Parse(dtCursoTemaVideo.Rows[0]["IdCT"].ToString());
                miCursoTemaVideo.IdVideo = int.Parse(dtCursoTemaVideo.Rows[0]["IdVideo"].ToString());




                return View(miCursoTemaVideo);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }
        }


        public ActionResult DeleteCursoTemaVideo(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", id));



            DataTable dtCursoTemaVideo = BaseHelper.ejecutarConsulta("sp_CTV_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso_Tema_Video miCursoTemaVideo = new Curso_Tema_Video();

            if (dtCursoTemaVideo.Rows.Count > 0)
            {


                miCursoTemaVideo.IdCTV = int.Parse(dtCursoTemaVideo.Rows[0]["IdCTV"].ToString());
                miCursoTemaVideo.IdCT = int.Parse(dtCursoTemaVideo.Rows[0]["IdCT"].ToString());
                miCursoTemaVideo.IdVideo = int.Parse(dtCursoTemaVideo.Rows[0]["IdVideo"].ToString());




                return View(miCursoTemaVideo);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult DeleteCursoTemaVideo(int id, FormCollection frm)
        {
            //obtener info del video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", id));

            BaseHelper.ejecutarConsulta("sp_CTV_Eliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("CTVideo_list");
        }

        public ActionResult EditCursoTemaVideo(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", id));



            DataTable dtCursoTemaVideo = BaseHelper.ejecutarConsulta("sp_CTV_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso_Tema_Video miCursoTemaVideo = new Curso_Tema_Video();

            if (dtCursoTemaVideo.Rows.Count > 0)
            {


                miCursoTemaVideo.IdCTV = int.Parse(dtCursoTemaVideo.Rows[0]["IdCTV"].ToString());
                miCursoTemaVideo.IdCT = int.Parse(dtCursoTemaVideo.Rows[0]["IdCT"].ToString());
                miCursoTemaVideo.IdVideo = int.Parse(dtCursoTemaVideo.Rows[0]["IdVideo"].ToString());




                return View(miCursoTemaVideo);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EditCursoTemaVideo(int id, Curso_Tema_Video datos)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdCTV", id));
            parametros.Add(new SqlParameter("@IdCT", id));
            parametros.Add(new SqlParameter("@IdVideo", id));

            BaseHelper.ejecutarConsulta("sp_CTV_Actualizar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("CTVideo_list");


        }

        //------------------

    }
}
