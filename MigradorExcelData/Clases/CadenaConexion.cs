using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigradorExcelData.Clases
{
    public class CadenaConexion
    {
        public string IpBaseDatos { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string NombreEsquema { get; set; }
        public string NombreTabla { get; set; }
    }
}