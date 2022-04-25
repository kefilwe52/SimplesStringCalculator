using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStringCalculator
{
    public class StringCalculator
    {
        private const string CustomDelimiter = "//";

        public int Add(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            try
            {
                if (string.IsNullOrEmpty(numbers))
                    return 0;

                if (numbers.StartsWith(CustomDelimiter))
                {
                    var newLineSplit = numbers.Split(new[] { '\n' }, 2);
                    var customDelimiter = newLineSplit[0].Replace(CustomDelimiter, string.Empty);
                    delimiters.Add(customDelimiter);
                    numbers = newLineSplit[1];
                }

                var numberList = numbers.Split(delimiters.ToArray(), StringSplitOptions.None)
                    .Select(int.Parse).ToList();

                var negatives = numberList?.Where(x => x < 0).ToList();

                if (negatives.Any())
                    throw new FormatException("Negative numbers are not allowed: " + string.Join(",", negatives));

                return numberList.Sum();
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}