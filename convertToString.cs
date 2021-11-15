using System;
using System.Collections.Generic;
namespace currency
{
    public static class convertToString
    {
        private static string[] digitUnits = { "", "thousand ", "million ", "billion ", "trillion ", "quadrillion " };
        private static readonly Dictionary<string, string> integers
            = new Dictionary<string, string>{
                {"0",""},
                {"1", "one "},
                {"2","two "},
                {"3", "three "},
                {"4","four "},
                {"5","five "},
                {"6","six "},
                {"7","seven "},
                {"8","eight "},
                {"9","nine "},
                {"10","ten "},
                {"11","eleven "},
                {"12","twelve "},
                {"13","thirteen "},
                {"14","fourteen "},
                {"15","fifteen "},
                {"16","sixteen "},
                {"17","seventeen "},
                {"18","eighteen "},
                {"19","nineteen "},
                {"20","twenty "},
                {"30", "thirty "},
                {"40","forty "},
                {"50", "fifty "},
                {"60","sixty "},
                {"70","seventy "},
                {"80","eighty "},
                {"90","ninety "},
        };
        /*
        **  Takes input string and converts it to the verbal representation.
        **  Assumes input is valid and cents will be 1-2dp if present.
        */
        public static string parseInputToString(string input)
        {
            try
            {
                words.wordNumbers outputString = new words.wordNumbers();
                string result = "No result";

                int hasZeros = Int32.Parse(input.Replace(".", ""));
                if (hasZeros == 0)
                {
                    Console.WriteLine("Null input");
                    return "-1";
                }
                else if ((input.IndexOf(".") != -1) && (input.Length - input.IndexOf(".") > 3))
                {
                    Console.WriteLine("Incorrect cents input");
                    return "-1";
                }

                //check if number is a decimal
                if (input.IndexOf(".") == -1)
                {
                    result = noDecimal(input);
                    outputString.concatString = result;

                }
                else
                {
                    result = hasDecimal(input);
                    outputString.concatString = result;
                }
                return outputString.concatString;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return "-1";
            }
            finally
            {
                Console.WriteLine("Exiting..");
            }
        }
        /*
        **  Converts two input digits and returns the verbal value
        */
        private static string convertTwoDigits(string input)
        {
            //if value is between 0-9
            string convertedAmount = "";
            if (input.Substring(0, 1) == "0")
            {
                convertedAmount = integers[input.Substring(1)];
            }

            else
            {
                //if value between 10-19 or between 20-99
                convertedAmount = input.Substring(0, 1) == "1" ? integers[input] : integers[input.Substring(0, 1) + "0"] + integers[input.Substring(1)];

            }
            return convertedAmount;
        }
        /*
        **  Converts three digit input into verbal value
        **  Takes input of the three digits, the unit identified for the millions etc and whether 0's have been added
        */
        private static string convertThreeDigits(string dollars, int unit, bool added)
        {
            string hundreds = "";
            string tens = "";
            //if zeros have been added to the front of the dollars
            if (added == false)
            {
                //convert the hundred
                hundreds = integers[dollars.Substring(0, 1)];
            }
            //convert the tens
            tens = convertTwoDigits(dollars.Substring(1, 2)) + digitUnits[(unit / 3) - 1];
            //If the inputted string is pure zeros, don't input "hundred"
            if (dollars == "000") return "";
            //If zeros have been added, return the tens value which have been calculated above
            if (added == true) return tens;
            //Handles whether only the hundreds need to be added or tens needs to as well.
            return dollars.Substring(1, 2) == "00" ? hundreds + "hundred " : hundreds + "hundred and " + tens;
        }

        /*
        **  Method for handling converting the dollar part of the number
        **  Method takes in three numbers at a time
        */
        private static string convertDollars(string dollarsNum)
        {
            string dollars = "";
            int i = 0;
            bool added = false;
            int unitLength = 0;

            //if number is not multiple of 3 digits, add one or two 0's
            if ((3 - dollarsNum.Length % 3) == 1)
            {
                dollarsNum = "0" + dollarsNum;
                added = true;
            }
            else if ((3 - dollarsNum.Length % 3) == 2)
            {
                dollarsNum = "00" + dollarsNum;
                added = true;
            }

            unitLength = dollarsNum.Length;
            for (i = 0; i < dollarsNum.Length; i += 3)
            {
                dollars += convertThreeDigits(dollarsNum.Substring(i, 3), unitLength, added);
                added = false;
                unitLength -= 3;
            }
            return dollars;
        }
        /*
        **  Method for handling converting the cents part of the number
        **  Method takes in two numbers at a time
        */

        private static string hasDecimal(string input)
        {
            //remove the decimal point
            string dollar = "";
            string cents = "";
            //if the inputted cents is not 2dp then we add a 0 i.e. 20.3 becomes 20.30
            if (input.IndexOf(".") == input.Length - 2)
            {
                input = input + "0";
            }
            input = input.Replace(".", "");
            //getting dollars value
            dollar = convertDollars(input.Substring(0, input.Length - 2)) + "dollars ";
            //getting cents value
            if (input.Substring(input.Length - 2) != "00")
            {
                cents = "and " + convertTwoDigits(input.Substring(input.Length - 2)) + "cents";
            }
            return dollar + cents;
        }

        /*
        **  Method for handling converting the pure dollar part of the number
        */
        private static string noDecimal(string input)
        {
            //getting dollars value
            return convertDollars(input) + "dollars ";
        }
    }
}