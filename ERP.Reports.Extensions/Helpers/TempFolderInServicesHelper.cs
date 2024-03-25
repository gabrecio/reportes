using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ERP.Reports.Extensions.Helpers
{
    public static class TempFolderInServicesHelper
    {
        public static string GetTempFolder()
        {
            try
            {
                string text = ConfigurationManager.AppSettings["IIS.TempFolder"];
                if (!string.IsNullOrEmpty(text))
                {
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }

                    return text;
                }

                return Path.GetTempPath();
            }
            catch (Exception)
            {
                return Path.GetTempPath();
            }
        }

        public static DirectoryInfo CreateRandomDirectory()
        {
            string randomFileName = Path.GetRandomFileName();
            return Directory.CreateDirectory(Path.Combine(GetTempFolder(), randomFileName));
        }

        public static void TryDeleteFile(string fullPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
                {
                    string directoryName = Path.GetDirectoryName(fullPath);
                    File.Delete(fullPath);
                    string[] files = Directory.GetFiles(directoryName);
                    if (!files.Any())
                    {
                        TryDeleteDirectory(directoryName, recursive: true);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void TryDeleteDirectory(string fullPath, bool recursive)
        {
            try
            {
                if (!string.IsNullOrEmpty(fullPath) && Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, recursive);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}