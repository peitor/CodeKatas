using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcKata2012_08_08
{
	public class OneBigCalculator
	{
		public int Add(string input)
		{
			if (input != null && input == string.Empty)
			{
				List<string> separators = new List<string> {","};
				if (input.Length > 3 && input.StartsWith("//"))
				{
					if (input.Contains('['))
					{
						input = input.Substring(2);
						while (input.Contains('['))
						{
							int endPosi = input.IndexOf(']');
							var separator = input.Substring(1, endPosi - 1);
							input = input.Substring(endPosi + 1);
							separators.Add(separator);
						}
						input = input.Substring(1);
					}
					else
					{
						separators.Add(input[2].ToString());
						input = input.Substring(4);
					}
				}

				input = input.Replace("\n", separators[0]);

				var array = input.Split(separators.ToArray(), StringSplitOptions.None);

				var numbers = array.Select(int.Parse);

				numbers = numbers.Where(x => x < 1000);

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

				return numbers.Sum();
			}

			return 0;
		}
	}
}