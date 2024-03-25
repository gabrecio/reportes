using CSharpFunctionalExtensions;
using ERP.Reports.Api.Interfaces.Repository;
using ERP.Reports.Api.Models.Core;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses.Core;
using ERP.Reports.Components;
using ERP.Reports.Extensions;
using ERP.Reports.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Services.Core
{
    public abstract class ReportHandlerBase
    {
        public IReportRepository ReportRepository { get; }

        public ReportHandlerBase(IReportRepository reportRepository)
        {
            ReportRepository = reportRepository;
        }
        public async Task<Result<FileModel>> GetReportDTO(GetReportRequest reportRequest)
        {

            CustomReportParameter customReportParamDTO = reportRequest.CustomReportParameters ?? new CustomReportParameter();
            TransactionBasic transactionBasic = reportRequest.Transaction;
            string reportId = reportRequest.ReportId;
            Dictionary<string, object> parameters = reportRequest.Parameters;

            var reportViewResult = await GetReportView(transactionBasic.OrganizationId, reportId, customReportParamDTO);
            if (reportViewResult.IsFailure)
                return Result.Failure<FileModel>(reportViewResult.Error);
            return await GetReportInternal(reportViewResult.Value, parameters, transactionBasic, customReportParamDTO);

        }
        private async Task<Result<FileModel>> GetReportInternal(ReportView report, Dictionary<string, object> parameters, TransactionBasic transactionBasic, CustomReportParameter customReportParamDTO)
        {
            string friendlyName = report.FriendlyName;
            if (!string.IsNullOrEmpty(transactionBasic.Number))
                friendlyName = $"{friendlyName}_{transactionBasic.Number}.pdf";
            else
                friendlyName = $"{friendlyName}.pdf";

            Maybe<string> maybeReportPath = GetReportPath();
            var reportPath = maybeReportPath
                .ToResult("Report Path Not Set")
                .Map(path => Path.Combine(path, report.FileName));

            if (reportPath.IsFailure)
                return Result.Failure<FileModel>(reportPath.Error);

            var ds = await this.ReportRepository.GetReportData(report, parameters);
            var guidReport = Guid.NewGuid().ToString();
            var temporalPathFolder = Path.Combine(TempFolderInServicesHelper.GetTempFolder(), guidReport);
            try
            {
                Directory.CreateDirectory(temporalPathFolder);

                var friendlyNameNormalize = friendlyName.NormalizeFileName();
                var fullFilePath = Path.Combine(temporalPathFolder, friendlyName);
                byte[] bytesOfRPT = File.ReadAllBytes(reportPath.Value);
                using (var customReportDocument = ReportManager.CreateReport(friendlyNameNormalize, bytesOfRPT, ds))
                {
                    customReportDocument.Export(fullFilePath);
                    byte[] bytesExportFile = File.ReadAllBytes(fullFilePath);

                    return FileModel
                        .Create(transactionBasic
                        , friendlyNameNormalize
                        , GetWeightForCustomer(report.Id)
                        , bytesExportFile
                        , report.EmailAttached
                        , report.PrinterId
                        , report.PrinterName
                        , report.ReportEntityPrinters);

                }
            }
            finally
            {
                TempFolderInServicesHelper.TryDeleteDirectory(temporalPathFolder, true);
            }
        }

        private static string GetReportPath()
        {
            var reportPath = "Reports";

            if (System.Web.Hosting.HostingEnvironment.ApplicationHost != null)
            {
                //hosted on web
                reportPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/bin/" + reportPath);
            }
            else
            {
                //hosted on console
                var directoryInfo = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory;
                if (directoryInfo != null)
                {
                    reportPath = Path.Combine(directoryInfo.FullName, reportPath);
                }
            }

            return reportPath;
        }
        private static int GetWeightForCustomer(string reportId)
        {
            switch (reportId)
            {
                case ReportsValues.QuickPacking:
                    return 1000;

                case ReportsValues.BillOfLading:
                    return 900;

                case ReportsValues.ShipmentPackageLabel:
                    return 800;

                case ReportsValues.QuickPickingPalletWeightAndDims:
                    return 700;

                case ReportsValues.PickingPipeTally:
                    return 600;

                case ReportsValues.CommercialInvoice:
                    return 500;

                case ReportsValues.MTR:
                    return 400;

                case ReportsValues.CertificateOfComplaiance:
                    return 300;

                case ReportsValues.Invoice:
                    return 200;

                default:
                    return 0;

            }
        }
        private async Task<Result<ReportView>> GetReportView(int organizationId, string reportId, CustomReportParameter customReportParamDTO)
        {

            //Get Report
            Maybe<ReportView> maybeReportView = await this.ReportRepository.GetReport(organizationId, reportId);
            if (!maybeReportView.HasValue)
                return maybeReportView.ToResult($"Cannot find report {reportId}");
            ReportView reportView = maybeReportView.Value;
            //Check for customization
            if (customReportParamDTO.EntityId.HasValue && customReportParamDTO.CustomReportType.HasValue && reportView.ReportCustomizations != null && reportView.ReportCustomizations.Any())
            {
                var customization = reportView.ReportCustomizations
                    .SingleOrDefault(x => x.OrganizationId == organizationId &&
                                                              x.Id == reportId &&
                                                              x.CustomizationTypeId == customReportParamDTO.CustomReportType &&
                                                              x.EntityId == customReportParamDTO.EntityId);

                if (customization != null)
                {
                    maybeReportView = await ReportRepository.GetReport(customization.OrganizationId, customization.ReportId);
                    if (reportView == null)
                        return maybeReportView.ToResult($"Cannot find report {customization.ReportId}");
                    reportView = maybeReportView.Value;
                }
            }

            return reportView;
        }

        protected static CustomReportParameter GetCustomReportParamsForCustomer(int customerId)
            => new CustomReportParameter
            {
                CustomReportType = (int)ReportCustomizationTypes.Customer,
                EntityId = customerId
            };
    }
}