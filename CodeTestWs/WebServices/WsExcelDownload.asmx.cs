using CodeTestWs.Helpers;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CodeTestWs.WebServices
{
    /// <summary>
    /// WebService de teste para download de excel.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class WsExcelDownload : System.Web.Services.WebService
    {
        public HttpResponse Response => HttpContext.Current.Response;

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public void DownloadExcel()
        {
            var data = new[]
            {
                new {Name = "Ram", Email = "ram@techbrij.com", Phone = "111-222-3333"},
                new {Name = "Shyam", Email = "shyam@techbrij.com", Phone = "159-222-1596"},
                new {Name = "Mohan", Email = "mohan@techbrij.com", Phone = "456-222-4569"},
                new {Name = "Sohan", Email = "sohan@techbrij.com", Phone = "789-456-3333"},
                new {Name = "Karan", Email = "karan@techbrij.com", Phone = "111-222-1234"},
                new {Name = "Brij", Email = "brij@techbrij.com", Phone = "111-222-3333"}
            };

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Contact.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            ExcelHelper.WriteTsv(data, Response.Output);
            Response.End();
        }
    }
}
