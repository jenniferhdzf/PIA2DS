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


        public ActionResult Video()
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
            parametros.Add (new SqlParameter ( "@Nombre",datosvideo.Nombre ));

            parametros.Add(new SqlParameter("@Url", datosvideo.Url));
            parametros.Add(new SqlParameter("@FechaPublicacion", datosvideo.FechaPublicacion));

            BaseHelper.ejecutarSentencia("sp_Video_Insertar",CommandType.StoredProcedure, parametros );
            return RedirectToAction("JHFRIAS");

        }


    }
}
