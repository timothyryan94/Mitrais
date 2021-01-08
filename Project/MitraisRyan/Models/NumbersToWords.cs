using System;
using System.Collections.Generic;
using System.Text;

namespace MitraisRyan.Models
{
    public class NumbersToWords
    {
        public decimal NumberTobeConverted { get; set; }

        public NumbersToWords() { }
        public NumbersToWords(decimal _Number) { this.NumberTobeConverted = _Number; }

        public string ConvertToWord()
        {
            return Dollar_Currency_Words(this.NumberTobeConverted, "dollar", "cent");
        }

        private string Numbers_1_Below20(int param)
        {
            string result = "";
            switch (param)
            {
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eight"; break;
                case 9: result = "nine"; break;
                case 10: result = "ten"; break;
                case 11: result = "eleven"; break;
                case 12: result = "twelve"; break;
                case 13: result = "thirteen"; break;
                case 14: result = "fourteen"; break;
                case 15: result = "fifteen"; break;
                case 16: result = "sixteen"; break;
                case 17: result = "seventeen"; break;
                case 18: result = "eighteen"; break;
                case 19: result = "nineteen"; break;
            }
            return result;
        }

        private string Numbers_Tens(int param)
        {
            string result = "";
            int tens = param / 10;
            if (tens <= 1)
            {
                result += " " + Numbers_1_Below20(param);
            }
            else
            {
                switch (tens)
                {
                    case 2: result = "twenty-"; break;
                    case 3: result = "thirty-"; break;
                    case 4: result = "forty-"; break;
                    case 5: result = "fifty-"; break;
                    case 6: result = "sixty-"; break;
                    case 7: result = "seventy-"; break;
                    case 8: result = "eighty-"; break;
                    case 9: result = "ninety-"; break;
                }

                if ((param % 10) == 0) { result = result.Replace("-", ""); }
                else { result += Numbers_1_Below20(param - tens * 10); }
            }

            return result.Trim();
        }

        private string Numbers_Hundreds(int param)
        {
            string result = "";
            string words = " hundred and ";
            int hundreds = param / 100;
            int remain = param % 100;
            if (hundreds > 0) { result = Numbers_1_Below20(hundreds) + words; }
            if (remain > 0) { result += Numbers_Tens(remain); }
            if (hundreds > 0 && remain == 0) { result = result.Replace(" and ", ""); }
            return result.Trim();
        }

        private string Numbers_All(decimal param)
        {
            const decimal cons_quadrillions = 1000000000000000;
            const decimal cons_trillions = 1000000000000;
            const decimal cons_billlions = 1000000000;
            const decimal cons_millions = 1000000;
            const decimal cons_thousands = 1000;
            string result = "";
            decimal[] arrValue;
            string[] arrName;
            int count_digits = 0;
            int i = 0;
            arrValue = new decimal[6];
            arrName = new string[6];

            arrName[0] = "quadrillion";
            arrName[1] = "trillion";
            arrName[2] = "billion";
            arrName[3] = "million";
            arrName[4] = "thousand";
            arrName[5] = "";
            arrValue[0] = cons_quadrillions;
            arrValue[1] = cons_trillions;
            arrValue[2] = cons_billlions;
            arrValue[3] = cons_millions;
            arrValue[4] = cons_thousands;
            arrValue[5] = 1;

            for (i = 0; i < 6; i++)
            {
                if (param >= arrValue[i])
                {
                    count_digits = (int)(param / arrValue[i]);
                    if (result.Length > 0) { result += ", "; }
                    result += Numbers_Hundreds(count_digits) + " " + arrName[i];
                    param -= count_digits * arrValue[i];
                }
            }
            return result.Trim();
        }

        private string Dollar_Currency_Words(decimal param, string curr, string penny)
        {
            string result = "";
            string minus_word = "";
            decimal dollars = (Int64)param;
            string dollars_result = "";
            if (param < 0)
            {
                minus_word = "minus ";
                dollars = dollars * -1;
                param = param * -1;
            }
            int cents = (int)((param - dollars) * 100);

            if (dollars != 1) { curr += "s"; }
            if (cents != 1) { penny += "s"; }

            dollars_result = minus_word;
            dollars_result += Numbers_All(dollars);
            string cents_result = Numbers_All(cents);

            if (dollars == 0) { dollars_result += "zero"; }
            dollars_result += " " + curr;
            if (cents_result.Length == 0) { cents_result = ""; }
            else { cents_result = "and " + cents_result + " " + penny; }

            result = dollars_result + " " + cents_result;
            return result.Trim().ToUpper();
        }
    }
}
