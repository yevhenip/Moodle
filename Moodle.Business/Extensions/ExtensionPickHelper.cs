using System.Collections.Generic;
using System.Linq;

namespace Moodle.Business.Extensions
{
    public static class ExtensionPickHelper
    {
        private const string DocPath = @"\svg\doc.svg";
        private const string PdfPath = @"\svg\pdf.svg";
        private const string ZipPath = @"\svg\zip.svg";
        private const string ExelPath = @"\svg\exel.png";
        private const string DbPath = @"\svg\db.png";
        private const string PptPath = @"\svg\ppt.png";
        private const string TaskPath = @"\svg\task.svg";
        private const string LinkPath = @"\svg\link.svg";

        private static readonly Dictionary<string, string> Patterns = new()
        {
            {".doc", DocPath},
            {".rtf", DocPath},
            {".docx", DocPath},
            {".pdf", PdfPath},
            {".zip", ZipPath},
            {".rar", ZipPath},
            {".xls", ExelPath},
            {".xlsx", ExelPath},
            {".db", DbPath},
            {".accdb", DbPath},
            {".ppt", PptPath},
            {".pptx", PptPath},
            {"task", TaskPath},
            {"link", LinkPath}
        };

        public static IEnumerable<string> PickExtensions(this IEnumerable<string> fileNames)
        {
            return fileNames.Select(fileName => Patterns[fileName]);
        }

        public static string PickExtension(this string fileName)
        {
            return Patterns[fileName];
        }
        
        public static string PickTask()
        {
            return Patterns["task"];
        }
        
        public static string PickLink()
        {
            return Patterns["link"];
        }
    }
}