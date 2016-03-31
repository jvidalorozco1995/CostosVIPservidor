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
   public class CostoEntradoBll
    {


       public static string CostoEntrado(string Proyecto, string Fecha)
       {
           string sSql = "SELECT 0,obradet.obrdcodi+obradet.obrdpres+liqmate.liqmcapi+liqmate.liqmdest+liqmate.liqmmate AS 'Referencia1', obradet.obrdnomb AS 'NombrePpto', liqmate.liqmfech AS 'fecha', liquida.liqupedi AS 'orden', liquida.liqunume AS '#liqu', liquida.liquprov AS 'codterc', tercero.tercnomb AS 'Nombre', liqmate.liqmcapi AS 'cap', capitul.capidesc AS 'Nombrecap', liqmate.liqmdest AS 'apu', unitari.unitdesc AS 'NombreAPU', insumos.insucodi AS 'Codigo', insumos.insudesc AS 'Descripcion', insumos.insuunid AS 'Unidad', liqmate.liqmliqu AS 'cantent', ((liqmate.liqmunit*(1+liqmate.liqmpiva/100))+((liqmate.liqmadmv/liqmate.liqmliqu)+(liqmate.liqmimpv/liqmate.liqmliqu)+(liqmate.liqmutiv/liqmate.liqmliqu)+(liqmate.liqmivav/liqmate.liqmliqu))) AS 'vrunitentrado', (((liqmate.liqmliqu*liqmate.liqmunit)*(1+liqmate.liqmpiva/100))+(liqmate.liqmimpv+liqmate.liqmadmv+liqmate.liqmutiv+liqmate.liqmivav)) AS 'costoentrado', liquida.liquusua AS 'usuario'," + Fecha
           + " FROM capitul capitul, insumos insumos, liqmate liqmate, liquida liquida, obradet obradet, obraspr obraspr, tercero tercero, unitari unitari"
           + " WHERE obradet.obrdcodi = liquida.liqusucu AND obradet.obrdcodi = obraspr.obracodi AND obradet.obrdpres = liquida.liqupres AND liquida.liqupres = liqmate.liqmpres AND liquida.liqunume = liqmate.liqmnume AND liquida.liqusucu = liqmate.liqmsucu AND liquida.liquprov = tercero.terccodi AND liqmate.liqmcapi = capitul.capicomp AND liqmate.liqmdest = unitari.unitcodi AND insumos.insucodi = liqmate.liqmmate AND ((liquida.liquanul<>1) AND (liqmate.liqmnobl<>1) AND (liquida.liqufech<={d '2020-12-31'}) AND (obradet.obrdcodi='" + Proyecto + "') AND (capitul.capiobra=liqmate.liqmsucu+liqmate.liqmpres And capitul.capiobra<>''))";
           return sSql;
       }



       public static string ListCostoEntrado(string Proyecto,string Fecha)
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
                      DataTable TablaCostoEntrado = cn.VerTabla1(CostoEntrado(Proyecto, Fecha), "CostoEntrado");
                   cn.Cerrar1();

                   return JsonConvert.SerializeObject(TablaCostoEntrado, Formatting.Indented);
               }
               else
               {

                   return "Exception Proyecto o Fecha vacia";
               }

           }catch(Exception ex){

               return "Exception" + ex;
           }

       }

    }
}
