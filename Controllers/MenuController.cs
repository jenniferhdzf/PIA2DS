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
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View();
        }

    }
}
