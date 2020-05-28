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
        Repositorio_Video repoVideo = new Repositorio_Video();
                //
        // GET: /Video/

        
        public ActionResult JHFRIAS()
        {
            return View(repoVideo.obtenerVideos());

        }
        public ActionResult Index()
        {
            return View();
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
            return View(repoVideo.obtenerVideo(id));

        }

        public ActionResult DeleteVideo(int id)
        {

            return View(repoVideo.obtenerVideo(id));

        }
    
        [HttpPost]

        public ActionResult DeleteVideo(int id, FormCollection frm)
        {
            repoVideo.eliminarVideo(id);
            return RedirectToAction("JHFRIAS");
        }
        
        public ActionResult EditVideo(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }
        
        [HttpPost]
        public ActionResult EditVideo(int id, Video datos)
        {
            datos.IdVideo = id;
            repoVideo.actualizarVideo(datos);
            return RedirectToAction("JHFRIAS");


        }


    }

}