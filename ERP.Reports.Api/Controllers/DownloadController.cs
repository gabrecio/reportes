using ERP.Reports.Api.Controllers.Core;
using ERP.Reports.Api.Interfaces.Services;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Reports.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DownloadController : MvcControllerBase
    {
        private readonly IReportService reportService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportService"></param>
        public DownloadController(IReportService reportService) => this.reportService = reportService;


        public ActionResult Index() => View(new DownloadViewModel());
        [HttpPost]
        public async Task<ActionResult> Download(DownloadViewModel download)
        {
            download.Errors.Clear();
            try
            {
                var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GetReportRequest>(download.Json);
                if (request != null
                    && !string.IsNullOrEmpty(request.ReportId)
                    && request.Parameters != null)
                {
                    var file = await reportService.GetReport(request);
                    return ProcessFile(file);
                }
                else
                {
                    download.Errors.Add("Invalid deseralization");
                }
            }
            catch (System.Exception ex)
            {

                download.Errors.Add(ex.Message);
            }
            return View("Index", download);
        }



    }
}