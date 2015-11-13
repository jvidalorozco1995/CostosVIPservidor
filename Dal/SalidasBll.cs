using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCostosServerVIP;
using Newtonsoft.Json;

namespace Dal
{
   public  class SalidasBll
    {

       public static string Salidas(string Proyecto, string Fecha)
       {

           string sSql = "SELECT 0,salidas.saliobra+salidas.salicapi+salidas.saliunit+salidas.saliinsu AS 'referencia', salidas.salifech AS 'fecha', salidas.saliliqu AS 'liquidacion', salidas.salivale AS 'vale consumo', salidas.salisali AS 'salida', salidas.salitipo AS 'tiposa', salidas.salicapi AS 'cod capi', salidas.saliunit AS 'cod unita', salidas.saliinsu AS 'cod insum', insumos.insudesc AS 'insumo', salidas.salicant AS 'cant', salidas.salicost*(1+salidas.salipiva/100+ordenes.ordeadmi/100+ordenes.ordeimp1/100+ordenes.ordeutil/100+(ordenes.ordeutil/100*ordenes.ordeivau/100))*salidas.salicant AS 'cost sali',"
      + " salidas.saliobse , salidas.saliusua,"+ Fecha 
      + " FROM insumos insumos, liquida liquida, ordenes ordenes, salidas salidas"
      + " WHERE insumos.insucodi = salidas.saliinsu AND salidas.saliliqu = liquida.liqunume AND liquida.liqupedi = ordenes.ordenume AND ((salidas.salitipo<>$4) AND (salidas.salianul<>1) AND (LEFT(saliobra,3)='" + Proyecto + "') AND (salidas.saliobra=liquida.liqusucu+liquida.liqupres And salidas.saliobra=ordenes.ordesucu+ordenes.ordepres And salidas.saliobra<>''))";

           return sSql;
       }


       public static string ListSalidas(string Proyecto,string Fecha) {

           try
           {
               if (Proyecto != "" && Fecha != "")
               {
                   //Abrir la Conexion
                   Utilidades cn = new Utilidades();
                   //Ejecutar los Comando que Deseemos.
                   // Recordemos que el Metodo Ejecutar no Regresa un Objeto del tipo DataSet que es como una Colecion de Tablas. Y si queremos poner el resultado del comando en una Tabla hariamos lo siguiente:
                   //Antes de Terminar permiten Recomendarles la forma de utilizar la clase Conexion y el Manejo de Excepciones.
                   cn.Abrir1();
                     DataTable TablaSalidas = cn.VerTabla1(Salidas(Proyecto, Fecha), "Salidas");
                   cn.Cerrar1();

                   return JsonConvert.SerializeObject(TablaSalidas, Formatting.Indented);
               }
               else {

                   return "Exception Proyecto o Fecha vacia";
               
               }
           }
           catch (Exception ex) {

               return "Exception" + ex;
           }
        }

    }
}
