using Dal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebCostosServerVIP.Servicios
{
    /// <summary>
    /// Summary description for SalidasWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SalidasWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Salidas(string Proyecto,string IdFecha)
        {
            return SalidasBll.ListSalidas(Proyecto, IdFecha);
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
