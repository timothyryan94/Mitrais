using System;
using System.Globalization;
using MitraisRyan.Models;
namespace MitraisRyan
{
    class Program
    {
        static void Main(string[] args)
        {
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            var numbersToWords = new NumbersToWords();
            decimal dec_number;
            string input = "";
            string result = "";

            Console.WriteLine("Input the Number:");
            input = Convert.ToString(Console.ReadLine());
            if (decimal.TryParse(input, out dec_number))
            {
                numbersToWords.NumberTobeConverted = dec_number;
                result = numbersToWords.ConvertToWord();
                Console.WriteLine($"The result is : {result}");
            }
            else
            {
                Console.WriteLine("Please input the valid number.");
            }
            Console.ReadKey();
        }
    }
}
