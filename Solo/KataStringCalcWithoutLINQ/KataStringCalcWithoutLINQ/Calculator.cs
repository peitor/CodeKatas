using System;
using System.Collections.Generic;
using System.Globalization;

namespace KataStringCalcWithoutLINQ
{
	public class Calculator
	{
		public int Add(string input)
		{
			if (string.IsNullOrEmpty(input))
				return 0;

			var separators = GetSeparators(ref input);

			var arrayOfStrings = input.Split(separators, StringSplitOptions.None);
			
			ThrowIfNegativeNumbers(arrayOfStrings);

			var sum = Sum(arrayOfStrings);

			return sum;
		}

		private static int Sum(IEnumerable<string> arrayOfStrings)
		{
			int sum = 0;
			foreach (var str in arrayOfStrings)
			{
				var nr = int.Parse(str);

				nr = AllowedNumber(nr);
				
				sum += nr;
			}
			return sum;
		}

		private static int AllowedNumber(int nr)
		{
			if (nr >= 1000)
			{
				return 0;
			}

			return nr;
		}


		private static string[] GetSeparators(ref string input)
		{
			List<string> separators =  new List<string>{",", "\n"};

			if (input.StartsWith("//"))
			{
				if (input[2] == '[')
				{
					input = RemoveTrailingSlashes(input);

					while (input.Contains("["))
					{
						int endPosi = input.IndexOf("]", StringComparison.Ordinal);
						separators.Add(input.Substring(1, endPosi - 1));
						input = input.Substring(endPosi + 1);
					}

					input = RemoveNewLineChar(input);
				}
				else
				{
					separators.Add(input[2].ToString(CultureInfo.InvariantCulture));
					input = input.Substring(4);
				}
			}
			return separators.ToArray();
		}

		private void ThrowIfNegativeNumbers(IEnumerable<string> arrayOfStrings)
		{
		
			List<int> negativeNumbers = new List<int>();

			foreach (var str in arrayOfStrings)
			{
				var nr = int.Parse(str);
				if (nr < 0)
				{
					negativeNumbers.Add(nr);
				}
			}

			ThrowIfNegativeNumbers(negativeNumbers);
		}

		private static void ThrowIfNegativeNumbers(IReadOnlyCollection<int> negativeNumbers)
		{
			if (negativeNumbers.Count > 0)
			{
				var msg = "negatives not allowed: ";
				foreach (var negNr in negativeNumbers)
				{
					msg = msg + negNr + " ";
				}

				throw new ArgumentException(msg);
			}
		}

		private static string RemoveNewLineChar(string input)
		{
			return input.Substring(1);
		}

		private static string RemoveTrailingSlashes(string input)
		{
			return input.Substring(2);
		}
	}
}