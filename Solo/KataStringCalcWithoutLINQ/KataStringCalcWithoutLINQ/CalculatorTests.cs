using System;
using NUnit.Framework;

namespace KataStringCalcWithoutLINQ
{
	public class CalculatorTests
	{
		Calculator c = new Calculator();


		[Test]
		public void HandleEmpty()
		{
			Assert.That(c.Add(""), Is.EqualTo(0));
		}

		[Test]
		public void HandleNull()
		{
			Assert.That(c.Add(null), Is.EqualTo(0));
		}

		[Test]
		public void Handle1Nr_ReturnNr()
		{
			Assert.That(c.Add("1"), Is.EqualTo(1));
		}

		[Test]
		public void Handle2Nr_ReturnSum()
		{
			Assert.That(c.Add("1,2"), Is.EqualTo(3));
		}

		[Test]
		public void HandleHeapsOfNr()
		{
			Assert.That(c.Add("1,2,3,4,5,6,7,8,9"), Is.EqualTo(45));
		}

		[Test]
		public void HandleNewLines_AsDelimiter()
		{
			Assert.That(c.Add("1\n2"), Is.EqualTo(3));
		}

		[Test]
		public void SupportDifferentDelimiters()
		{
			Assert.That(c.Add("//;\n1;2"), Is.EqualTo(3));
		}
		
		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void NegativeNumber_Throws()
		{
			c.Add("1,-1");
		}
		
		[Test]
		[ExpectedException(ExpectedMessage = "negatives not allowed: -1 -2 ")]
		public void MultiNegativeNumber_ThrowsAllMessage()
		{
			c.Add("-1,-2");
		}
		
		[Test]
		public void NumbersBiggerThan1000_Ignore()
		{
			Assert.That(c.Add("1000,1"), Is.EqualTo(1));
		}

		[Test]
		public void SupportLongerDelimiters()
		{
			Assert.That(c.Add("//[***]\n1***2***3"), Is.EqualTo(6));
		}

		[Test]
		public void SupportMultipleLongerDelimiters()
		{
			Assert.That(c.Add("//[*][%]\n1*2%3"), Is.EqualTo(6));
		}
		



		[Test]
		[TestCase("1,1", 2)]
		[TestCase("1,2,3", 6)]
		[TestCase("1,3,4", 8)]
		[TestCase("1,2,3,4,5,6,7,8,9", 45)]
		[TestCase("1\n2,3", 6)]
		public void DataDriven(string input, int expected)
		{
			Assert.That(c.Add(input), Is.EqualTo(expected));
		}

	}
}
