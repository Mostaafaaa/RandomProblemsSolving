using System;
using System.Globalization;
using System.Text.RegularExpressions;


namespace MostafaOmarExtractPhoneNameAndPriceFromHtmlFile
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            string HtmlFilePath = @"D:\CSharp\Halal almshakl\MostafaOmarExtractPhoneNameAndPriceFromHtmlFile\WebPageForPhoneNameAndPrice.html";
            string HtmlFilePhoneAndPriceFile = ReadingFiles.ReadHtmlFile(HtmlFilePath);

            ExtractPhoneNameAndPhonePriceFromHtmlPage(HtmlFilePhoneAndPriceFile);
        }

        public static void ExtractPhoneNameAndPhonePriceFromHtmlPage(string input)
        {
            try
            {
                //check safety
                if (string.IsNullOrWhiteSpace(input))
                    throw new Exception("Error! The Input is empty or contains only spaces.");

                //.*?: stops in the new line

                // the problem we faced was using .*?, it takes anything in the same line only. 
                // here i made this [\s\S] which mean match any white spaces character or any nonspacec character

                string PhoneNamePattren = @"<h3 class=""product-title"">(.*?)</h3>[\s\S]*?";
                string PhonePricePattren = @"<span class=""price-tag"">(.*?)</span>";
                string PhoneNameAndPricePattren = PhoneNamePattren + PhonePricePattren;
                MatchCollection PhoneNameAndPriceMatches = Regex.Matches(input, PhoneNameAndPricePattren);

                if (PhoneNameAndPriceMatches.Count > 0)
                {
                    foreach (Match match in PhoneNameAndPriceMatches)
                    {
                        Console.WriteLine($"Phone Name : {match.Groups[1].Value} \nPhone Price : {match.Groups[2].Value}");
                    }
                }
                else
                {
                    Console.WriteLine("No Phone name was found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error ocured" + ex);
            }
        }
    }
}
