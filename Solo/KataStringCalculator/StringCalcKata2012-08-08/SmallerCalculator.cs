using System;
using System.Linq;

namespace StringCalcKata2012_08_08
{
	public class SmallerCalculator
	{
		public int Add(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return 0;
			}

			Calc calc = new Calc(input);

			calc.DetermineSeparator();
			
			string[] array = calc.SplitInput();

			var numbers = array.Select(int.Parse);

			numbers = numbers.Where(x => x < 1000);

			//ThrowIfContainsNegativeNumbers(numbers);

			return numbers.Sum();


			return 0;
		}
	}

	public class Calc
	{
		private string _input;
		private string separator = ",";

		public Calc(string input)
		{
			_input = input;
		}

		public void DetermineSeparator()
		{
			if (_input.Length > 3 && _input.StartsWith("//") && _input[3] == '\n')
			{
				separator = _input[2].ToString();
				_input = _input.Substring(4);

			}

		}

		//input = input.Replace("\n", separators[0]);

		public string[] SplitInput()
		{
			return _input.Split(new string[] { separator }, StringSplitOptions.None);

		}
	}
}