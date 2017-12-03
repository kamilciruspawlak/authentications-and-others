using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public object Add(string input)
        {
            var separators = new List<char>()
            {
                ',',
                '\n',
            };
            if (input.Contains("//"))
            {
                separators.Add(input[2]);
                input = input.Substring(4, input.Length - 4);
            }
            if (!ValidateInput(input))
            {
                return 0;
            }
            var numbers = input.Split(separators.ToArray());
            ValidateNegativeNmbers(numbers);
            return numbers.Sum(number => int.Parse(number));
        }

        private static void ValidateNegativeNmbers(string[] numbers)
        {
            var negativeNumbers = new List<string>();
            foreach (var negativeNumber in numbers)
            {
                if (negativeNumber.Contains("-"))
                {
                    negativeNumbers.Add(negativeNumber);
                }
            }
            if (negativeNumbers.Count > 0)
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }
        }

        private static bool ValidateInput(string input)
        {
            if (input.Contains(",\n"))
            {
                throw new ArgumentException();
            }
            return (!string.IsNullOrEmpty(input));
        }
       
    }
}
