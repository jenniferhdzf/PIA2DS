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


        public ActionResult CreateCursoTema()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CreateCursoTema(Curso_Tema datosCursoTema)
        {

            //GUARDAR TEMA EN LA BASE DE DATOS

            List<SqlParameter> parametros = new List<SqlParameter>();

            
            
            parametros.Add(new SqlParameter("@IdCurso",datosCursoTema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCursoTema.IdTema));


            BaseHelper.ejecutarSentencia("sp_Curso_Tema_Insertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("CT_list");

        }



        public ActionResult DetailsCursoTema(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", id));



            DataTable dtCursoTema = BaseHelper.ejecutarConsulta("sp_Curso_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso_Tema miCursoTema = new Curso_Tema();

            if (dtCursoTema.Rows.Count > 0)
            {


                miCursoTema.IdCT = int.Parse(dtCursoTema.Rows[0]["IdCT"].ToString());
                miCursoTema.IdCurso = int.Parse(dtCursoTema.Rows[0]["IdCurso"].ToString());
                miCursoTema.IdTema = int.Parse(dtCursoTema.Rows[0]["IdTema"].ToString());




                return View(miCursoTema);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }
        }

        public ActionResult DeleteCursoTema(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", id));



            DataTable dtCursoTema = BaseHelper.ejecutarConsulta("sp_Curso_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso_Tema miCursoTema = new Curso_Tema();

            if (dtCursoTema.Rows.Count > 0)
            {
               

                miCursoTema.IdCT = int.Parse(dtCursoTema.Rows[0]["IdCT"].ToString());
                miCursoTema.IdCurso = int.Parse(dtCursoTema.Rows[0]["IdCurso"].ToString());
                miCursoTema.IdTema = int.Parse(dtCursoTema.Rows[0]["IdTema"].ToString());


                

                return View(miCursoTema);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }
                         
        }

        


         public ActionResult EditCursoTema(int id)
             {
                 //consultar los datos del video

                 List<SqlParameter> parametros = new List<SqlParameter>();
                 parametros.Add(new SqlParameter("@IdCT", id));



                 DataTable dtCursoTema = BaseHelper.ejecutarConsulta("sp_Curso_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

                 Curso_Tema miCursoTema = new Curso_Tema();

                 if (dtCursoTema.Rows.Count > 0)
                 {


                     miCursoTema.IdCT = int.Parse(dtCursoTema.Rows[0]["IdCT"].ToString());
                     miCursoTema.IdCurso = int.Parse(dtCursoTema.Rows[0]["IdCurso"].ToString());
                     miCursoTema.IdTema = int.Parse(dtCursoTema.Rows[0]["IdTema"].ToString());




                     return View(miCursoTema);
                 }
                 else
                 {
                     //no encontrado 
                     return View("Error");
                 }

             }
             [HttpPost]
         public ActionResult EditCursoTema(int id, Curso_Tema datos)
             {
                 List<SqlParameter> parametros = new List<SqlParameter>();
                 
                 parametros.Add(new SqlParameter("@IdCT", id));
                 parametros.Add(new SqlParameter("@IdCurso", id));
                 parametros.Add(new SqlParameter("@IdTema",id));

                 BaseHelper.ejecutarConsulta("sp_Curso_Tema_Actualizar", CommandType.StoredProcedure, parametros);
                 return RedirectToAction("CT_list");


             }






        //----------------------------
    }
}

