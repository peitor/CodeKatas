using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcKata2012_08_08
{
	public class Calculator
	{
		public int Add(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return 0;
			}

			string[] separators = GetSeparators(ref input);

			input = input.Replace("\n", separators[0]);

			var array = input.Split(separators, StringSplitOptions.None);

			var numbers = array.Select(int.Parse);

			numbers = numbers.Where(x => x < 1000);

			ThrowIfContainsNegativeNumbers(numbers);

			return numbers.Sum();

		}

		private string[] GetSeparators(ref string input)
		{
			List<string> separators = new List<string> { "," };
			if (input.Length > 3 && input.StartsWith("//"))
			{
				if (input.Contains('['))
				{
					input = RemoveLeadindDashes(input);
					while (input.Contains('['))
					{
						separators.Add(GetSeparatorsInner(ref input));
					}
					input = SkipOverNewLine(input);
				}
				else
				{
					separators.Add(input[2].ToString());
					input = input.Substring(4);
				}
			}
			return separators.ToArray();
		}

		private static string SkipOverNewLine(string input)
		{
			return input.Substring(1);
		}

		private static string RemoveLeadindDashes(string input)
		{
			return input.Substring(2);
		}

		private string GetSeparatorsInner(ref string input)
		{
			int endPosi = input.IndexOf(']');
			var separator = input.Substring(1, endPosi - 1);
			input = input.Substring(endPosi + 1);

			return separator;
		}

		private static void ThrowIfContainsNegativeNumbers(IEnumerable<int> numbers)
		{
			var negativeNumbers = numbers.Where(x => x < 0);
			if (negativeNumbers.Any())
			{
				var negativesNotAllowed = "negatives not allowed: ";
				foreach (var nr in negativeNumbers)
				{
					negativesNotAllowed = negativesNotAllowed + nr + " ";
				}

				throw new ArgumentException(negativesNotAllowed);
			}
		}
	}
}