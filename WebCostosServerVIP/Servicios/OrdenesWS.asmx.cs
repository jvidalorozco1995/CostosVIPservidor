using Dal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebCostosServerVIP.Servicios
{
    /// <summary>
    /// Summary description for OrdenesWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public   class OrdenesWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Ordenes(string Proyecto,string IdFecha)
        {

          return OrdenesBll.ListOrdenes(Proyecto,IdFecha);
        
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

    public static  class Hola{
   
        public static DataTable ParseXML(string xmlString)
        {

            DataSet ds = new DataSet();
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
            Stream memory = new MemoryStream(xmlBytes);
            ds.ReadXml(memory);
            return ds.Tables[0];
        }



        /*public static string ConvertDataTableToString(this DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            dt.Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
            {
                dt.Columns.Cast<DataColumn>().ToList().ForEach(column =>
                {
                    stringBuilder.AppendFormat("{0}:{1} ", column.ColumnName, dataRow[column]);
                });
                stringBuilder.Append(Environment.NewLine);
            });
            return stringBuilder.ToString();
        }*/
}

}
