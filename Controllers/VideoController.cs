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
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }


       


        public ActionResult JHFRIAS()
        {

            //obtener todos los videos
            DataTable dtVideos = BaseHelper.ejecutarConsulta("sp_Video_ConsultarTodo", CommandType.StoredProcedure);

            List<Video> lstvideos = new List<Video>();

            //convertir el DataTable en List<Video>

            foreach (DataRow item in dtVideos.Rows)
            {
                Video datosVideo = new Video();

                datosVideo.IdVideo = int.Parse(item["IdVideo"].ToString());
                datosVideo.Nombre = item["Nombre"].ToString();
                datosVideo.Url = item["Url"].ToString();
                datosVideo.FechaPublicacion = DateTime.Parse(item["FechaPublicacion"].ToString());

                lstvideos.Add(datosVideo);

            }

            return View(lstvideos);


        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(Video datosvideo)
        {

            //GUARDAR VIDEOS EN LA BASE DE DATOS

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosvideo.Nombre));

            parametros.Add(new SqlParameter("@Url", datosvideo.Url));
            parametros.Add(new SqlParameter("@FechaPublicacion", datosvideo.FechaPublicacion));

            BaseHelper.ejecutarSentencia("sp_Video_Insertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("JHFRIAS");

        }


        public ActionResult DetailsVideo(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", id));



            DataTable dtVideo = BaseHelper.ejecutarConsulta("sp_Video_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Video miVideo = new Video();

            if (dtVideo.Rows.Count > 0)
            {
                miVideo.IdVideo = int.Parse(dtVideo.Rows[0]["IdVideo"].ToString());
                miVideo.Nombre = dtVideo.Rows[0]["Nombre"].ToString();
                miVideo.Url = dtVideo.Rows[0]["Url"].ToString();
                miVideo.FechaPublicacion = DateTime.Parse(dtVideo.Rows[0]["FechaPublicacion"].ToString());
                return View(miVideo);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }

        public ActionResult DeleteVideo(int id)
        {
            //obtener info del video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", id));

            DataTable dtVideo = BaseHelper.ejecutarConsulta("sp_Video_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Video miVideo = new Video();

            if (dtVideo.Rows.Count > 0)
            {
                miVideo.IdVideo = int.Parse(dtVideo.Rows[0]["IdVideo"].ToString());
                miVideo.Nombre = dtVideo.Rows[0]["Nombre"].ToString();
                miVideo.Url = dtVideo.Rows[0]["Url"].ToString();
                miVideo.FechaPublicacion = DateTime.Parse(dtVideo.Rows[0]["FechaPublicacion"].ToString());
                return View(miVideo);
            }
            else
            {  //no encontrado 
                return View("Error");
            }

        }



        [HttpPost]
        public ActionResult DeleteVideo(int id, FormCollection frm)
        {
            //obtener info del video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", id));

            BaseHelper.ejecutarConsulta("sp_Video_Eliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("JHFRIAS");
        }



    }

}