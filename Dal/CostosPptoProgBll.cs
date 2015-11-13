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
   public class CostosPptoProgBll
    {

       public static string CostosPresuProg(string Proyecto, string Filtro, string Fecha)
       {

           string sSql = "SELECT 0,detactr.dectobra+detactr.dectcapi+detactr.dectunit+detactr.dectinsu AS 'referencia1', detactr.dectobra+detactr.dectcapi+detactr.dectunit AS 'referencia2', detactr.dectobra+detactr.dectinsu AS 'referencia3', obradet.obrdnomb AS 'presupuesto', detactr.dectcapi AS 'codcapi', capitul.capidesc AS 'capitulo', detactr.dectunit AS 'codunit', unitari.unitdesc AS 'unitario', unitari.unitunid AS 'undunita', cantobr.cantcant AS 'cantxppto', detactr.dectinsu AS 'codinsu', insumos.insutipo, insumos.insudesc AS 'insumo', insumos.insuunid AS 'unidinsu', precins.precinve AS 'ctrlinven', detactr.dectavan AS 'validacion', precins.precvalo AS 'precioppto', detauni.detacant AS 'consumounitario', detactr.dectauti AS 'consumototal', detactr.dectadic AS 'adic', precins.precautv AS 'precioaut'," + Fecha
      + " FROM cantobr cantobr, capitul capitul, detactr detactr, detauni detauni, insumos insumos, obradet obradet, precins precins, unitari unitari"
      + " WHERE detactr.dectunit = unitari.unitcodi AND detactr.dectcapi = capitul.capicomp AND detactr.dectobra = capitul.capiobra AND detactr.dectinsu = insumos.insucodi AND cantobr.cantcomp = detactr.dectcapi AND cantobr.cantobra = detactr.dectobra AND cantobr.cantunit = detactr.dectunit AND detauni.detaobra = detactr.dectobra AND detauni.detaunit = detactr.dectunit AND detauni.detainsu = detactr.dectinsu AND precins.precobra = detactr.dectobra AND precins.preccodi = detactr.dectinsu AND ((detactr.dectobra=obradet.obrdcodi+obradet.obrdpres  AND (obradet.obrdcodi='" + Proyecto + "')))";
           return sSql;
       }



       public static string ListCostosPresuProg(string Proyecto, string Filtro, string Fecha)
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
                      DataTable TablaCostosPresuProg = cn.VerTabla1(CostosPresuProg(Proyecto, Filtro, Fecha), "Ordenes");
                   cn.Cerrar1();

                   return JsonConvert.SerializeObject(TablaCostosPresuProg, Formatting.Indented);
               }
               else
               {

                   return "Exception Proyecto o Fecha vacia";
               }
           }
           catch (Exception ex)
           {

               return "Exception" + ex;
           }

       }

    }
}
