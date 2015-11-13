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
    public class DescuentosBll
    {

        


         public static string Descuentos(string Proyecto, string Fecha)
        {

            string sSql = "SELECT 0,descobra+descpres+desccapi+descdest+descinsu,descterc, descliqu, descobra, descconc, descvalo, descpres," + Fecha
            +" FROM descuen descuen"
            +" WHERE (descuen.descliqu<>'') AND (descuen.descobra='" + Proyecto + "') AND (descuen.descconc Not Like '%RETEIVA%')";  
               return sSql;
        }


       
       public static string ListDescuentos(string Proyecto, string Fecha)
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
                        DataTable TablaDescuentos = cn.VerTabla1(Descuentos(Proyecto, Fecha), "Descuentos");
                   cn.Cerrar1();

                   return JsonConvert.SerializeObject(TablaDescuentos, Formatting.Indented);
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
