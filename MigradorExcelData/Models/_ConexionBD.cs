using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MigradorExcelData.Clases;
using MySql.Data.MySqlClient;

namespace MigradorExcelData.Models
{
    public class _ConexionBD
    {
        static public Respuesta PruebaConexion(CadenaConexion cadenaconec)
        {
            Respuesta resp = new Respuesta();
            resp.Error = false;

            string conexion = "Database=" + cadenaconec.NombreEsquema + "; Data Source =" + cadenaconec.IpBaseDatos + "; User Id=" + cadenaconec.Usuario + "; Password=" + cadenaconec.Password + "";

            MySqlConnection conexionBD = new MySqlConnection(conexion);
            MySqlDataReader lector = null;

            try
            {
                string consulta = "SHOW DATABASES";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                lector  = comando.ExecuteReader();

                while(lector.Read())
                {
                    resp.Mensaje += lector.GetString(0) + "\n";
                }
            }
            catch(Exception ex)
            {
                resp.Error = true;
                resp.Mensaje = ex.Message;
            }
            finally
            {
                conexionBD.Close();
            }

            return resp;
        }

        static public Respuesta InsertarRegistros(CadenaConexion cadenaconec, string queryinsert)
        {
            Respuesta resp = new Respuesta();
            resp.Error = false;

            string conexion = "Database=" + cadenaconec.NombreEsquema + "; Data Source =" + cadenaconec.IpBaseDatos + "; User Id=" + cadenaconec.Usuario + "; Password=" + cadenaconec.Password + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(conexion);
                MySqlCommand command = new MySqlCommand(queryinsert, conexionBD);
                MySqlDataReader lector;

                conexionBD.Open();
                lector = command.ExecuteReader();

                while (lector.Read()) 
                {
                    
                }

                conexionBD.Close();
            }
            catch (Exception e) 
            {
                resp.Error = true;
                resp.Mensaje = e.Message;
            }

            return resp;
        }
    }
}