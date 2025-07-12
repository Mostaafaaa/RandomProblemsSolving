using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace regex_exercises
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            string scrap = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n" +
                "    <title>My Awesome Store</title>\r\n</head>\r\n<body>\r\n " +
                "   <div class=\"product-card\">\r\n     " +
                "   <a href=\"/product/iphone-14-pro\">\r\n     " +
                "       <img src=\"https://store.example.com/img/iphone-14-pro.jpg\" alt=\"iPhone 14 Pro Max\" />\r\n   " +
                "         <h3 class=\"product-title\">iPhone 14 Pro Max</h3>\r\n    " +
                "    </a>\r\n        <span class=\"price-tag\">$1,099.99</span>\r\n  " +
                "  </div>\r\n\r\n    <div class=\"product-card\">\r\n     " +
                "   <a href=\"/product/galaxy-z-fold-5\">\r\n          " +
                "  <img src=\"https://store.example.com/img/galaxy-z-fold-5.jpg\" alt=\"Galaxy Z Fold 5\" />\r\n " +
                "           <h3 class=\"product-title\">Samsung Galaxy Z Fold 5</h3>\r\n      " +
                "  </a>\r\n        <span class=\"price-tag\">$1,799.00</span>\r\n    " +
                "</div>\r\n\r\n    <div class=\"product-card\">\r\n      " +
                "  <a href=\"/product/xiaomi-mi-13\">\r\n     " +
                "       <img src=\"https://store.example.com/img/xiaomi-mi-13.jpg\" alt=\"Xiaomi Mi 13\" />\r\n  " +
                "          <h3 class=\"product-title\">Xiaomi Mi 13</h3>\r\n        </a>\r\n  " +
                "      <span class=\"price-tag\">$699.00</span>\r\n    </div>\r\n\r\n    <div class=\"product-card\">\r\n   " +
                "     <a href=\"/product/nothing-phone-2\">\r\n           " +
                " <img src=\"https://store.example.com/img/nothing-phone-2.jpg\" alt=\"Nothing Phone 2\" />\r\n     " +
                "        <h3 class=\"product-title\">Nothing Phone (2)</h3>\r\n        </a>\r\n       " +
                " <span class=\"price-tag\">$599.00</span>\r\n    </div>\r\n</body>\r\n</html>";

            ExtractNameAndPrice(scrap);
        }
      
        public static void ExtractNameAndPrice(string input)
        {
            try
            {
                //check safety
                if (string.IsNullOrWhiteSpace(input))
                    throw new Exception("Error! The Input is empty or contains only spaces.");
                //string PriceAndPhoneNamePattren = @"<h3 class=""product-title"">(.?)</h3>\s<span class=""price-tag"">(.?)</span>";
                var PhoneName = Regex.Matches(input, @"<h3 class=""product-title"">(.*?)</h3>");

                if (PhoneName.Count > 0)
                {
                     string PhoneNames = string.Join(", ", PhoneName.Select(m => m.Groups[1].Value));
                    Console.WriteLine(PhoneNames);
                }
                else
                {
                    Console.WriteLine("No Phone name was found");
                
                }
                var PhonePrice = Regex.Matches(input, @"<span class=""price-tag"">(.*?)</span>");
                if (PhonePrice.Count > 0)
                {
                    string PhonePrices = string.Join(", ", PhonePrice.Select(m => m.Groups[1].Value));
                    Console.WriteLine(PhonePrices);
                }
                else
                {
                    Console.WriteLine("No Phone price was found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error ocured");
            }
        }
    }
}

