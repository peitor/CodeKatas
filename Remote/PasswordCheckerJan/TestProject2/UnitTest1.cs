using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace TestProject2
{

	[TestClass]
	public class UnitTest1
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCase(1, 2, 3, "Should contain special character")]
		[TestCase(10, 20, 30)]
		[TestCase(100, 200, 300)]
		public void TestMethod2()
		{
			TestContext.Run((int x, int y, int z) =>
			{
				(x + y).Is(z);
				(x + y + z).Is(i => i < 1000);
			});
		}



		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void When_Password_IsNull_ItShouldThrowAnException()
		{
			Checker.IsStrongPassword(null);
		}


		// 111111111111 --> false
		// x --> false
		// 

		[TestMethod]
		public void TestMethod1()
		{
			var result = Checker.IsStrongPassword("x");

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void When_Length_IsLessThen_Seven_ItShould_Return_False()
		{
			var result = Checker.IsStrongPassword("123456");
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void When_ContainsAtLeast1AlphabeticCharacter_ReturnFalse()
		{
			var result = Checker.IsStrongPassword("111111111111");
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void When_DoesntContainSpecialCharacter_ReturnFalse()
		{
			var result = Checker.IsStrongPassword("111111111111a");
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void When_NotContains_1Numeric_Character_Return_False()
		{
			var result = Checker.IsStrongPassword("ABCDEFGHI");
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void When_Password_Contains_An_SpecialCharacter_Return_True()
		{
			var result = Checker.IsStrongPassword("1234567AB#");
			Assert.AreEqual(result, true);
		}

	}

	public static class Checker
	{
		public static bool IsStrongPassword(string s)
		{
			Contract.Requires<ArgumentNullException>(s != null);

			return s.IsLongerThan(7) && ContainsNumber(s) && ContainsAlphaNumberic(s) && ContainsSpecialCharacter(s);
		}

		private static string And(this string s)
		{
			return s;
		}

		private static bool IsLongerThan(this string s, int length)
		{
			if (s.Length >= length)
			{
				return true;
			}
			return false;

		}

		private static bool ContainsAlphaNumberic(string s)
		{
			const string CHARACTERS = "ABCDEFGHAIJKLMNOPQRSTUVWXYZ";

			return ContainsCharacter(s, CHARACTERS);
		}


		private static bool ContainsNumber(string s)
		{
			const string NUMBERS = "1234567890";

			return ContainsCharacter(s, NUMBERS);
		}

		private static bool ContainsSpecialCharacter(string s)
		{
			const string SPECIAL_CHARACTERS = "#*+-();.";

			if (ContainsCharacter(s, SPECIAL_CHARACTERS))
			{
				return true;
			}


			return false;
		}

		private static bool ContainsCharacter(string s, string characters)
		{
			foreach (var character in characters)
			{
				if (s.Contains(character.ToString()))
				{
					return true;
				}
			}
			return false;
		}
	}
}
