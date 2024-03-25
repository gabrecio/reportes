using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ERP.Reports.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeFileName(this string fileName)
        {
            string arg = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string pattern = string.Format("([{0}]*\\.+$)|([{0}]+)", arg);
            return Regex.Replace(fileName, pattern, "_");
        }
        public static string NormalizeDirName(this string dirName)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(
                 new string(System.IO.Path.GetInvalidPathChars())
            );
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(dirName, invalidRegStr, "_");
        }
        public static string SpacesToSentence(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            for (var i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ' && !char.IsUpper(text[i - 1]))
                    newText.Append(' ');

                newText.Append(text[i]);
            }

            return newText.ToString();
        }
    }

}