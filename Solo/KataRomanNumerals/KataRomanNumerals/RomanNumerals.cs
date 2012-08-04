using System;
using System.Collections.Generic;

namespace KataRomanNumerals
{
	public class RomanNumerals
	{
		public string Convert(int input)
		{
			string result = "";

			List<Tuple<int, string>> romans =
				new List<Tuple<int, string>>
					{
						new Tuple<int, string>(1000, "M"),
						new Tuple<int, string>(900, "CM"),
						new Tuple<int, string>(500, "D"),
						new Tuple<int, string>(400, "CD"),
						new Tuple<int, string>(100, "C"),
						new Tuple<int, string>(90, "XC"),
						new Tuple<int, string>(50, "L"),
						new Tuple<int, string>(49, "IL"),
						new Tuple<int, string>(40, "XL"),
						new Tuple<int, string>(10, "X"),
						new Tuple<int, string>(9, "IX"),
						new Tuple<int, string>(5, "V"),
						new Tuple<int, string>(4, "IV"),
						new Tuple<int, string>(1, "I"),
					};

			foreach (var roman in romans)
			{
				int number = roman.Item1;

				while (input > number - 1)
				{
					result += roman.Item2;
					input = input - number;
				}
			}

			return result;
		}
	}
}