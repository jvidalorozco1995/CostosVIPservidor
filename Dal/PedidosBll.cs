using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCostosServerVIP;

namespace Dal
{
   public class PedidosBll
    {


       public static string Pedidos(string Proyecto, string Fecha)
       {

           string sSql = "SELECT 0,reqdeta.reqdsucu+reqdeta.reqdpre1+reqdeta.reqdcapi+reqdeta.reqddest+reqdeta.reqdmate AS 'referencia1', reqdeta.reqdcapi AS 'cod capi', reqdeta.reqddest AS 'cod unit', reqdeta.reqdmate AS 'cod insu',requisi.requfech AS 'fecha', reqdeta.reqdnume AS 'pedido', reqdeta.reqdrequ AS 'ped', (IIF(0=requapro And reqdapro<>0,0,reqdapro)) AS 'aprob', reqdeta.reqdpedi AS 'comp', (IIF(reqdeta.reqdapro-reqdeta.reqdpedi<0,0,reqdeta.reqdapro-reqdeta.reqdpedi)) AS 'x gen orden', reqdeta.reqdorde AS 'orden', reqdeta.reqdusua AS 'usuario'," + Fecha
           + " FROM reqdeta reqdeta, requisi requisi"
           + " WHERE reqdeta.reqdnume = requisi.requnume AND reqdeta.reqdsucu = requisi.requsucu AND reqdeta.reqdpre1 = requisi.requpres AND ((reqdeta.reqdsucu Like '%" + Proyecto + "%') AND (reqdeta.reqdpre1<>''))";
           return sSql;
       }


       
       public static string ListPedidos(string Proyecto, string Fecha)
       {

           try{

               if (Proyecto != "" && Fecha != "")
               {
                   //Abrir la Conexion
                   Utilidades cn = new Utilidades();
                   //Ejecutar los Comando que Deseemos.
                   // Recordemos que el Metodo Ejecutar no Regresa un Objeto del tipo DataSet que es como una Colecion de Tablas. Y si queremos poner el resultado del comando en una Tabla hariamos lo siguiente:
                   //Antes de Terminar permiten Recomendarles la forma de utilizar la clase Conexion y el Manejo de Excepciones.
                   cn.Abrir1();
                        DataTable TablaPedidos = cn.VerTabla1(Pedidos(Proyecto, Fecha), "Pedidos");
                   cn.Cerrar1();

                   return JsonConvert.SerializeObject(TablaPedidos, Formatting.Indented);
               }
               else {

                   return "Exception Proyecto o Fecha vacia";
               }

           }catch(Exception ex){

               return "Exception" + ex;
           }
          

       }

    }
}
