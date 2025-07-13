using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostafaOmarExtractPhoneNameAndPriceFromHtmlFile
{
    internal class ReadingFiles
    {
        public static string ReadHtmlFile (string HtmlFilePath)
        {
            string HtmlFile = System.IO.File.ReadAllText(HtmlFilePath);

            return HtmlFile;
        }

       
    }
}
