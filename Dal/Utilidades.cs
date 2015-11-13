using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebCostosServerVIP
{
    public class Utilidades
    {

        private OdbcConnection Con1; // Obj Conexion

        public Utilidades()
        {



            /* Para trabajar con el servidor SQLExpress de la maquina */
            string sConnectionString1 = ConfigurationManager.ConnectionStrings["ConexionCostosVIP"].ConnectionString;





            /* Para trabajar con un servidor remoto Ya sea una Base de datos Remota o en Caso de WEB SITE cuando la pongamos en el Host */

            /* Necesitamos la IP del Servidor de BD, el puerto generalmente es 1533, Usuario y Password lo proporciona el Hostring */

            //DtsConection = “Data Source=72.17.135.40,1533; Database=NOMBRE_BD; User ID=USUARIO; Password=PASSWORD;”;

            Con1 = new OdbcConnection(sConnectionString1);


        }

        public void Abrir1() // Metodo para Abrir la Conexion
        {

            Con1.Open();

        }

        public void Cerrar1() // Metodo para Cerrar la Conexion
        {

            Con1.Close();
        }

        public DataTable VerTabla1(string Comando, string Tabla) // Metodo para Ejecutar Comandos
        {

            OdbcDataAdapter CMD = new OdbcDataAdapter(Comando, Con1); // Creamos un DataAdapter con el Comando y la Conexion

            DataTable DS = new DataTable(); // Creamos el DataSet que Devolvera el Metodo
            DS.TableName = Tabla;
            CMD.Fill(DS); // Ejecutamos el Comando en la Tabla

            return DS; // Regresamos el DataSet

        }

    }
}

