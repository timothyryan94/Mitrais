using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitraisRyan.Models;
using System.Globalization;

namespace UnitTestProjectMitraisRyan
{
    [TestClass]
    public class UnitTest1
    {

        private void testparam(string parInput, string parExpectedResult)
        {
            NumbersToWords numbersToWords = new NumbersToWords();
            decimal dec_number;
            //try
            //{
            //    d = decimal.Parse(parInput, CultureInfo.InvariantCulture);
            //    x.NumberTobeConverted = d;
            //    Assert.AreEqual(parExpectedResult, x.ConvertToWord(), "Result is not matched.");
            //}
            //catch (System.Exception)
            //{

            //    throw;
            //}
            if (decimal.TryParse(parInput, NumberStyles.Any, new CultureInfo("en-US"), out dec_number))
            {
                numbersToWords.NumberTobeConverted = dec_number;
                Assert.AreEqual(parExpectedResult, numbersToWords.ConvertToWord(), "Result is not matched.");
            }
        }


        [TestMethod]
        public void TestMethod_Cent()
        {
            string input = "0.01";
            string expected_result = "ZERO DOLLARS AND ONE CENT";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_Cents()
        {
            string input = "0.25";
            string expected_result = "ZERO DOLLARS AND TWENTY-FIVE CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_OneDecimalCents()
        {
            string input = "0.2";
            string expected_result = "ZERO DOLLARS AND TWENTY CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_DecimalCents()
        {
            string input = "0.02";
            string expected_result = "ZERO DOLLARS AND TWO CENTS";
            testparam(input, expected_result);
        }
        [TestMethod]
        public void TestMethod_DotDecimalCents()
        {
            string input = ".86";
            string expected_result = "ZERO DOLLARS AND EIGHTY-SIX CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_MinusCent()
        {
            string input = "-0.01";
            string expected_result = "MINUS ZERO DOLLARS AND ONE CENT";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_MinusCents()
        {
            string input = "-0.33";
            string expected_result = "MINUS ZERO DOLLARS AND THIRTY-THREE CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_Zero()
        {
            string input = "0";
            string expected_result = "ZERO DOLLARS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_Dollar()
        {
            string input = "1";
            string expected_result = "ONE DOLLAR";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_DollarAndCents()
        {
            string input = "1.99";
            string expected_result = "ONE DOLLAR AND NINETY-NINE CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_DollarsAndCents()
        {
            string input = "123.45";
            string expected_result = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_MinusDollarAndCents()
        {
            string input = "-2.49";
            string expected_result = "MINUS TWO DOLLARS AND FORTY-NINE CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_DollarAndCent()
        {
            string input = "1.01";
            string expected_result = "ONE DOLLAR AND ONE CENT";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_DollarAndOneDecimalCent()
        {
            string input = "1.6";
            string expected_result = "ONE DOLLAR AND SIXTY CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_Dollars()
        {
            string input = "777";
            string expected_result = "SEVEN HUNDRED AND SEVENTY-SEVEN DOLLARS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_MinusDollars()
        {
            string input = "-300";
            string expected_result = "MINUS THREE HUNDRED DOLLARS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_MillionDollars()
        {
            string input = "123,456,789";
            string expected_result = "ONE HUNDRED AND TWENTY-THREE MILLION, FOUR HUNDRED AND FIFTY-SIX THOUSAND, SEVEN HUNDRED AND EIGHTY-NINE DOLLARS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_BillionDollars()
        {
            string input = "95,258,676,438.23";
            string expected_result = "NINETY-FIVE BILLION, TWO HUNDRED AND FIFTY-EIGHT MILLION, SIX HUNDRED AND SEVENTY-SIX THOUSAND, FOUR HUNDRED AND THIRTY-EIGHT DOLLARS AND TWENTY-THREE CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_Random()
        {
            string input = "08012021";
            string expected_result = "EIGHT MILLION, TWELVE THOUSAND, TWENTY-ONE DOLLARS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_TrillionDollarsAndCents()
        {
            string input = "123231312456564.64";
            string expected_result = "ONE HUNDRED AND TWENTY-THREE TRILLION, TWO HUNDRED AND THIRTY-ONE BILLION, THREE HUNDRED AND TWELVE MILLION, FOUR HUNDRED AND FIFTY-SIX THOUSAND, FIVE HUNDRED AND SIXTY-FOUR DOLLARS AND SIXTY-FOUR CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_ThousandDollarsAndOneDecimalCent()
        {
            string input = "8462.5";
            string expected_result = "EIGHT THOUSAND, FOUR HUNDRED AND SIXTY-TWO DOLLARS AND FIFTY CENTS";
            testparam(input, expected_result);
        }

        [TestMethod]
        public void TestMethod_MinusThousandDollarsAndOneDecimalCent()
        {
            string input = "-13557.9";
            string expected_result = "MINUS THIRTEEN THOUSAND, FIVE HUNDRED AND FIFTY-SEVEN DOLLARS AND NINETY CENTS";
            testparam(input, expected_result);
        }
    }
}
