using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCostosServerVIP;

namespace Dal
{
   public class AreasBll
    {
       public static string GuardarAreasConsulta()
       {
           string sSql = "SELECT 1,LEFT(inmuebl.inmuobra,3) AS 'Proyecto',obradet.obrdnomb, inmuebl.inmuobra, bloques.bloqcodi, bloques.bloqdesc, inmuebl.inmucodi, inmuebl.inmuvent, inmuebl.inmuarea FROM bloques bloques, inmuebl inmuebl, obradet obradet WHERE inmuebl.inmuobra = bloques.bloqobra AND ((inmuebl.inmuobra=obradet.obrdcodi+obradet.obrdpres) AND (bloques.bloqcodi=right(inmuebl.inmubloq,2)))";
           return sSql;
       }

       public static DataTable ListAreas()
       {

           //Abrir la Conexion
           Utilidades cn = new Utilidades();
           //Ejecutar los Comando que Deseemos.
           // Recordemos que el Metodo Ejecutar no Regresa un Objeto del tipo DataSet que es como una Colecion de Tablas. Y si queremos poner el resultado del comando en una Tabla hariamos lo siguiente:
           //Antes de Terminar permiten Recomendarles la forma de utilizar la clase Conexion y el Manejo de Excepciones.
           cn.Abrir1();
              DataTable TablaAreas = cn.VerTabla1(GuardarAreasConsulta(), "Areas");
           cn.Cerrar1();


           return TablaAreas;

       }

    }
}
