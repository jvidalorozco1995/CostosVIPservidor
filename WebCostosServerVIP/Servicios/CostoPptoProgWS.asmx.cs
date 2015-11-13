using Dal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebCostosServerVIP.Servicios
{
    /// <summary>
    /// Summary description for CostoPptoProgWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class CostoPptoProgWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CostosPptoProg(string Proyecto, string Filtro, string IdFecha)
        {
           
            return CostosPptoProgBll.ListCostosPresuProg(Proyecto,Filtro,IdFecha);
     
        }



        /*Me selecciona cuantas lineas quiero que se manden como un TOP EN SQL SERVER*/
        public DataTable SelectTopDataRow(DataTable dt, int count)
        {
            DataTable dtn = dt.Clone();
            for (int i = 0; i < count; i++)
            {
                dtn.ImportRow(dt.Rows[i]);
            }

            return dtn;
        }
    }
}
