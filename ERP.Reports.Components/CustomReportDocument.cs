using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP.Reports.Extensions;
using ERP.Reports.Extensions.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace ERP.Reports.Components
{
    public class CustomReportDocument : IDisposable
    {
        public ReportDocument RPT { get; private set; }
        public void Dispose()
        {
            if (this.RPT == null)
                return;

            this.RPT.TryExecute(() =>
            {
                this.DeleteTempFile();
                this.RPT.Close();
                this.RPT.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.WaitForFullGCComplete();
                GC.Collect();
                GC.WaitForFullGCComplete();
            });
        }

        private void DeleteTempFile()
        {
            if (this.RPT == null || string.IsNullOrEmpty(this.RPT.FilePath) || !File.Exists(this.RPT.FilePath))
                return;
            string tempFolder = Path.GetDirectoryName(this.RPT.FilePath);
            File.Delete(this.RPT.FilePath);
            var files = Directory.GetFiles(tempFolder);
            if (!files.Any())
                Directory.Delete(tempFolder);
        }
        public CustomReportDocument(string friendlyName, byte[] fileBytes, System.Data.DataSet data)
            : this(TempFolderInServicesHelper.GetTempFolder(), friendlyName, fileBytes, data)
        {
        }

        public CustomReportDocument(string mainTempPath, string friendlyName, byte[] fileBytes, System.Data.DataSet data)
        {
            if (string.IsNullOrEmpty(mainTempPath))
                mainTempPath = TempFolderInServicesHelper.GetTempFolder();

            if (string.IsNullOrWhiteSpace(friendlyName) || fileBytes == null || fileBytes.Length == 0 || data == null)
                return;

            var rpt = new ReportDocument();
            var printerName = rpt.PrintOptions.PrinterName;
            rpt.FileName = "";
            rpt.PrintOptions.PrinterName = printerName;

            var tempPath = Directory.CreateDirectory(Path.Combine(mainTempPath, Guid.NewGuid().ToString()));
            var fileNameNormalize = friendlyName.NormalizeFileName();
            var pathNameNormalize = tempPath.FullName.NormalizeDirName();
            var reportFile = Path.Combine(pathNameNormalize, fileNameNormalize + ".RPT");

            File.WriteAllBytes(reportFile, fileBytes);
            rpt.Load(reportFile);
            rpt.SetDataSource(data);

            this.RPT = rpt;
        }

        public byte[] Export(string fileName)
        {
            if (this.RPT == null || string.IsNullOrWhiteSpace(fileName))
                return null;

            var s = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(s))
                return null;

            var format = ExportFormatType.PortableDocFormat;
            var extension = s.ToLower();
            switch (extension)
            {
                case ".xls":
                    format = ExportFormatType.Excel;
                    break;

                case ".pdf":
                    format = ExportFormatType.PortableDocFormat;
                    break;

                case ".doc":
                    format = ExportFormatType.WordForWindows;
                    break;
            }
            //TODO: JPB VER SI ACA VA EL TEMA DE ESCAPE CARACTERES
            this.RPT.ExportToDisk(format, fileName);

            WaitWhileFileIsLocked(fileName);

            return File.ReadAllBytes(fileName);
        }

        private static void WaitWhileFileIsLocked(string fullPath)
        {
            FileInfo fileInfo = new FileInfo(fullPath);
            int maxAttemps = 10;
            int attemps = 0;
            while (IsFileLocked(fileInfo) && attemps <= maxAttemps)
            {
                Thread.Sleep(500);
                attemps++;
            }
        }

        static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open,
                         FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                stream?.Close();
                stream?.Dispose();
            }

            //file is not locked
            return false;
        }
    }
}
