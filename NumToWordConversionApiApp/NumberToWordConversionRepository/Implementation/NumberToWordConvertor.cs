using System;

namespace NumberToWordConversionRepository
{
    public class NumberToWordConvertor : IConvertor
    {
        public string ConvertNumberToWordFormat(double number)
        {            
            string word = ConvertNumberToWords(number);
            if (!string.IsNullOrEmpty(word))
            {
                word = word.Replace("  ", " ");
            }
            return word;
        }

        /// <summary>
        /// Convert the number to words
        /// </summary>
        /// <param name="input">8765.12</param>
        /// <returns>Eight Thousand Seven Hundred Sixty Five And One Two Cents Only</returns>
        private string ConvertNumberToWords(double input)
        {
            string prefixForNegativeNumber = "";
            string number = input.ToString();

            //if number is negative get the 'Minus' prefix
            if (input < 0)
            {
                prefixForNegativeNumber = "Minus ";
                //removes the '-' sign from the number for further processing
                number = number.Substring(1, number.Length - 1);
            }

            //if number is zero it returns the word format directly
            if (input == 0)
                return "Zero Only";

            //Concatenation of prefix('Minus' or '') with word format             
            string output = prefixForNegativeNumber + ConvertToWordsTheDecimalAndWholeNumberPart(number);

            return output;
        }

        /// <summary>
        /// Proces the decimal and whole number part of number to generate word format
        /// </summary>
        /// <param name="number">8765.12</param>
        /// <returns>Eight Thousand Seven Hundred Sixty Five And One Two Cents Only</returns>
        private string ConvertToWordsTheDecimalAndWholeNumberPart(string number)
        {            
            //Assigning the input assuming that it is whole number
            string numberBeforeDecimal = number;
            string numberAfterDecimal = "";

            //Check if number contains a decimal
            if (number.Contains("."))
            {
                int decimalIndex = number.IndexOf('.');
                //Assigning the whole number part of the input
                numberBeforeDecimal = number.Substring(0, decimalIndex);

                //Assigning the number after decimal
                numberAfterDecimal = number.Substring(decimalIndex + 1);

                //Decision if the value after decimal is required to be in the word format or not
                if (Convert.ToDouble(numberAfterDecimal) > 0)
                {
                    //Fetching the word format for number after decimal
                    numberAfterDecimal = ConvertWholeNumberToWord(numberAfterDecimal);                    
                }

                if (Convert.ToDouble(numberBeforeDecimal) > 0)
                {
                    //Fetching the word format for number before decimal
                    numberBeforeDecimal = ConvertWholeNumberToWord(numberBeforeDecimal).Trim();
                    
                    //Concatenation of number before decimal with number after decimal            
                    return string.Format("{0} {1} {2} {3}", numberBeforeDecimal, "And", numberAfterDecimal, "Cents Only");
                }
                else
                {
                    return string.Format("{0} {1}", numberAfterDecimal, "Cents Only");
                }                              
            }
            else
            {
                //Fetching the word format for number before decimal
                numberBeforeDecimal = ConvertWholeNumberToWord(numberBeforeDecimal).Trim();
                return string.Format("{0} {1}", numberBeforeDecimal, "Only");
            }
        }

        private static string ConvertWholeNumberToWord(string input)
        {
            string output = "";
            try
            {
                bool isComplete = false;//test if already converted the number    
                double num = (Convert.ToDouble(input));                  
                if (num > 0)
                {
                    int numberOfDigits = input.Length;
                    int position = 0;//store digit grouping    
                    string place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numberOfDigits)
                    {
                        case 1://unit place
                            output = UnitPlace(input);
                            isComplete = true;
                            break;
                        case 2://tens place    
                            output = TensPlace(input);
                            isComplete = true;
                            break;
                        case 3://hundreds place    
                            position = (numberOfDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands place    
                        case 5:
                        case 6:
                            position = (numberOfDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions place    
                        case 8:
                        case 9:
                            position = (numberOfDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions place   
                        case 11:
                        case 12:
                            position = (numberOfDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isComplete = true;
                            break;
                    }
                    if (!isComplete)
                    {
                        //Recursively converting the number substrings in to words   
                        if (input.Substring(0, position) != "0" && input.Substring(position) != "0")
                        {
                            try
                            {
                                // Concatenate the string with place like million, thousand, hundred and sepearately calls the function recursively to generate word format                                 
                                output = ConvertWholeNumberToWord(input.Substring(0, position)) + place + ConvertWholeNumberToWord(input.Substring(position));
                            }
                            catch { }
                        }
                        else
                        {
                            output = ConvertWholeNumberToWord(input.Substring(0, position)) + ConvertWholeNumberToWord(input.Substring(position));
                        }
                    }
                    //ignore digit grouping names    
                    if (output.Trim().Equals(place.Trim())) output = "";
                }
                else
                {
                    output = string.Empty;
                }
            }
            catch { }
            return output.Trim();
        }

        private static string UnitPlace(string input)
        {
            int number = Convert.ToInt32(input);
            string output = "";
            switch (number)
            {
                case 1:
                    output = "One";
                    break;
                case 2:
                    output = "Two";
                    break;
                case 3:
                    output = "Three";
                    break;
                case 4:
                    output = "Four";
                    break;
                case 5:
                    output = "Five";
                    break;
                case 6:
                    output = "Six";
                    break;
                case 7:
                    output = "Seven";
                    break;
                case 8:
                    output = "Eight";
                    break;
                case 9:
                    output = "Nine";
                    break;
            }
            return output;
        }

        private static string TensPlace(string input)
        {
            int number = Convert.ToInt32(input);
            string output = null;
            switch (number)
            {
                case 10:
                    output = "Ten";
                    break;
                case 11:
                    output = "Eleven";
                    break;
                case 12:
                    output = "Twelve";
                    break;
                case 13:
                    output = "Thirteen";
                    break;
                case 14:
                    output = "Fourteen";
                    break;
                case 15:
                    output = "Fifteen";
                    break;
                case 16:
                    output = "Sixteen";
                    break;
                case 17:
                    output = "Seventeen";
                    break;
                case 18:
                    output = "Eighteen";
                    break;
                case 19:
                    output = "Nineteen";
                    break;
                case 20:
                    output = "Twenty";
                    break;
                case 30:
                    output = "Thirty";
                    break;
                case 40:
                    output = "Fourty";
                    break;
                case 50:
                    output = "Fifty";
                    break;
                case 60:
                    output = "Sixty";
                    break;
                case 70:
                    output = "Seventy";
                    break;
                case 80:
                    output = "Eighty";
                    break;
                case 90:
                    output = "Ninety";
                    break;
                default:
                    if (number > 0)
                    {
                        //Appends zero after first digit then then recursively calls the tensplace method to get the first word
                        //and concactenate with the last digts word format by calling unitplace method
                        output = TensPlace(input.Substring(0, 1) + "0") + " " + UnitPlace(input.Substring(1));
                    }
                    break;
            }
            return output;
        }
    }
}