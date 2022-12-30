using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MigradorExcelData.Models;
using MigradorExcelData.Clases;

namespace MigradorExcelData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarRegistros(string cadenaconexion, string queryinsert)
        {
            CadenaConexion cc = JsonConvert.DeserializeObject<CadenaConexion>(cadenaconexion);
            Respuesta resp = _ConexionBD.InsertarRegistros(cc, queryinsert);

            return Json(resp);
        }
        public JsonResult PruebaConexion(string cadenaconexion)
        {
            CadenaConexion cc = JsonConvert.DeserializeObject<CadenaConexion>(cadenaconexion);
            Respuesta resp = _ConexionBD.PruebaConexion(cc);

            return Json(resp);
        }
    }
}