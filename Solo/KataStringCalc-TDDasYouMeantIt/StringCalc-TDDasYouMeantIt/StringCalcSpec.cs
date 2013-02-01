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
			

			result += int.Parse(input);
			
			
			
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Given2Numbers_ReturnSum()
		{
			const string input = "1,2";
			int result = 0;


			var array = input.Split(',');
			foreach (var s in array)
			{
				result += int.Parse(s);
			}
			
		
			Assert.AreEqual(3, result);
		}
	}
}
