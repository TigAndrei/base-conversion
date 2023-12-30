using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_b1_b2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number in source base: ");
            string inputNumber = Console.ReadLine();

            Console.Write("Enter the source base (between 2 and 16): ");
            int baseFrom = int.Parse(Console.ReadLine());

            Console.Write("Enter the destination base (between 2 and 16): ");
            int baseTo = int.Parse(Console.ReadLine());

            double numberInBase10 = ConvertToBase10(inputNumber, baseFrom);
            string result = ConvertFromBase10(numberInBase10, baseTo);

            Console.WriteLine($"({inputNumber}){baseFrom} -> ({result}){baseTo}");
        }

        static double ConvertToBase10(string number, int baseFrom)
        {
            double numInBase10 = 0;
            for (int i = 0; i < number.Length; i++)
            {
                char digit = number[i];
                int digitValue;

                if (char.IsDigit(digit))
                    digitValue = digit - '0';
                else
                    digitValue = char.ToUpper(digit) - 'A' + 10;
                numInBase10 = numInBase10 * baseFrom + digitValue;
            }
            return numInBase10;
        }

        static string ConvertFromBase10(double number, int baseTo)
        {
            if (number == 0)
                return "0";

            StringBuilder result = new StringBuilder();
            int intPart = (int)number;

            while (intPart > 0)
            {
                int remainder = intPart % baseTo;
                char digit;

                if (remainder >= 10)
                    digit = (char)('A' + remainder - 10);
                else
                    digit = (char)('0' + remainder);

                result.Insert(0, digit);
                intPart /= baseTo;
            }

            return result.ToString();
        }

    }
}
