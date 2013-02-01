using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalc_TDDasYouMeantIt
{
	[TestClass]
	public class StringCalcSpec
	{
		[TestMethod]
		public void Given1Number_ReturnSum()
		{
			const string input = "1";
			int result = 0;


			result = Sum(input, result);


			Assert.AreEqual(1, result);
		}

	

		[TestMethod]
		public void Given2Numbers_ReturnSum()
		{
			const string input = "1,2";
			int result = 0;


			result = Sum(input, result);

			
		
			Assert.AreEqual(3, result);
		}



		private static int Sum(string input, int result)
		{
			var array = input.Split(',');
			foreach (var s in array)
			{
				result += int.Parse(s);
			}
			return result;
		}
	}
}
