namespace ERP.Reports.Components
{
    public class ReportManager
    {
        public static CustomReportDocument CreateReport(string friendlyName, byte[] fileBytes, System.Data.DataSet data)
        {
            return new CustomReportDocument(friendlyName, fileBytes, data);
        }
        public static CustomReportDocument CreateReport(string mainTempPath, string friendlyName, byte[] fileBytes, System.Data.DataSet data)
        {
            return new CustomReportDocument(mainTempPath, friendlyName, fileBytes, data);
        }
    }
}
