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
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empleado_list()
        {

            //obtener todos los Temas
            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarTodo", CommandType.StoredProcedure);

            List<Empleado> lsEmpleado = new List<Empleado>();

            //convertir el DataTable en List<Tema>

            foreach (DataRow item in dtEmpleado.Rows)
            {
                Empleado datosEmpleado = new Empleado();
                datosEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                datosEmpleado.Nombre = item["Nombre"].ToString();
                datosEmpleado.Direccion = item["Direccion"].ToString();
                


                lsEmpleado.Add(datosEmpleado);

            }

            return View(lsEmpleado);


        }

        public ActionResult CreateEmpleado()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CreateEmpleado(Empleado datosEmpleado)
        {

            //GUARDAR TEMA EN LA BASE DE DATOS

            List<SqlParameter> parametros = new List<SqlParameter>();

            
            parametros.Add(new SqlParameter("@Nombre",datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datosEmpleado.Direccion));

          
            BaseHelper.ejecutarSentencia("sp_Empleado_Insertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Empleado_list");

        }

        public ActionResult DetailsEmpleado(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));



            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Empleado miEmpleado = new Empleado();

            if (dtEmpleado.Rows.Count > 0)
            {
                miEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());

                miEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                miEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();

                return View(miEmpleado);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }

        public ActionResult DeleteEmpleado(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));



            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Empleado miEmpleado = new Empleado();

            if (dtEmpleado.Rows.Count > 0)
            {
                miEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());

                miEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                miEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();

                return View(miEmpleado);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }

        [HttpPost]

        public ActionResult DeleteEmpleado(int id, FormCollection frm)
        {
            //obtener info del video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));

            BaseHelper.ejecutarConsulta("sp_Empleado_Eliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Empleado_list");
        }

        public ActionResult EditEmpleado(int id)
        {
            //consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));



            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Empleado miEmpleado = new Empleado();

            if (dtEmpleado.Rows.Count > 0)
            {
                miEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());

                miEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                miEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();

                return View(miEmpleado);
            }
            else
            {
                //no encontrado 
                return View("Error");
            }

        }



        [HttpPost]
        public ActionResult EditEmpleado(int id, Empleado datos)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));
            parametros.Add(new SqlParameter("@Nombre", datos.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datos.Direccion));

            BaseHelper.ejecutarConsulta("sp_Empleado_Actualizar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Empleado_list");


        }


        //------------------------------

    }
}
