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
   public class OrdenesBll
    {

       public static string Ordenes(string Proyecto, string Fecha)
       {

           string sSql = "SELECT 0,ordedet.deorsucu+ordedet.deorpres+ordedet.deorcapi+ordedet.deordest+ordedet.deormate AS 'referencia1', obradet.obrdnomb AS 'presupuesto', ordedet.deordest AS 'cod unit', unitari.unitdesc AS 'unitario', ordedet.deormate AS 'cod insu', insumos.insudesc AS 'insumo', insumos.insuunid AS 'und', ordedet.deororde AS 'comp', ordedet.deorreci AS 'ent', ordedet.deororde-ordedet.deorreci AS 'x ent', ordenes.ordefech AS 'fecha', ordedet.deornume AS 'orden', ordenes.ordetipo AS 'tipo', ordenes.ordeprov AS 'cod prov', tercero.tercnomb AS 'proveedor', ((ordedet.deorunit*(1+ordedet.deorpiva/100))+((ordedet.deoradmv/ordedet.deororde)+(ordedet.deorimpv/ordedet.deororde)+(ordedet.deorutiv/ordedet.deororde)+(ordedet.deorivav/ordedet.deororde))) AS 'vlunitario',"
           + " ((ordedet.deorunit*(1+ordedet.deorpiva/100))+((ordedet.deoradmv/ordedet.deororde)+(ordedet.deorimpv/ordedet.deororde)+(ordedet.deorutiv/ordedet.deororde)+(ordedet.deorivav/ordedet.deororde)))*ordedet.deororde AS 'costo ent', ordedet.deorusua AS 'usuario'," + Fecha
           + " FROM insumos insumos, obradet obradet, ordedet ordedet, ordenes ordenes, tercero tercero, unitari unitari"
           + " WHERE ordedet.deornume = ordenes.ordenume AND ordedet.deorpres = ordenes.ordepres AND ordedet.deorsucu = ordenes.ordesucu AND ordenes.ordeprov = tercero.terccodi AND ordedet.deorsucu = obradet.obrdcodi AND ordedet.deorpres = obradet.obrdpres AND ordedet.deormate = insumos.insucodi AND ordedet.deordest = unitari.unitcodi AND ((ordedet.deornobl<>1) AND (ordedet.deorsucu='" + Proyecto + "') AND (ordenes.ordenume >='000001') AND (ordedet.deororde >0))";


           return sSql;
       }

       public static string ListOrdenes(string Proyecto,string Fecha)
       {
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
                      DataTable TablaOrdenes = cn.VerTabla1(Ordenes(Proyecto, Fecha), "Ordenes");
                   cn.Cerrar1();

                   return JsonConvert.SerializeObject(TablaOrdenes, Formatting.Indented);
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
