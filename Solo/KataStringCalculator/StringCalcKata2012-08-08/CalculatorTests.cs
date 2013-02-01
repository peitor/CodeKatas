using System;
using NUnit.Framework;


//#Resharper IGNOREXXX

namespace StringCalcKata2012_08_08
{
	[TestFixture]
	public class CalculatorSpecification
	{
		readonly SmallerCalculator sut = new SmallerCalculator();

		[Test]
		public void GivenEmpty_Returns0()
		{
			int result = sut.Add("");

			//nunit
			Assert.That(0, Is.EqualTo(result));

			//mstest
			//Assert.AreEqual(0, result);
		}

		[Test]
		public void GivenNull_Returns0()
		{
			int result = sut.Add(null);
			//Assert.That(0, Is.EqualTo(result));
		}


		[Test]
		public void GivenNr_ReturnsNr()
		{
			int result = sut.Add("1");
			//Assert.That(1, Is.EqualTo(result));
		}

		[Test]
		public void GivenNewLineInString_TreatAsSeparator()
		{
			int result = sut.Add("1\n2");
			//Assert.That(3, Is.EqualTo(result));
		}

		[Test]
		public void GivenDashes_SwitchDelimiter()
		{
			int result = sut.Add("//;\n1;2");
			Assert.That(3, Is.EqualTo(result));
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void GivenANegativeNr_Throws()
		{
			sut.Add("-1");
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1 -2 ")]
		public void GivenMoreNegativeNrs_Throws_ExpectMessage()
		{
			sut.Add("-1,-2");
		}

		[Test]
		public void GivenNrBiggerThan1000_IgnoreThem()
		{
			int result = sut.Add("1000,1");
			Assert.That(1, Is.EqualTo(result));
		}


		[Test]
		public void DelimiterOfAnyLenght_SwitchDelimiter()
		{
			int result = sut.Add("//[***]\n1***2***3");
			Assert.That(6, Is.EqualTo(result));
		}

		[Test]
		public void MultipleDelimiters_SwitchDelimiter()
		{
			int result = sut.Add("//[*][%]\n1*2%3");
			Assert.That(6, Is.EqualTo(result));
		}

		[Test]
		public void MultipleDelimiterOfAnyLenght_SwitchDelimiter()
		{
			int result = sut.Add("//[***][%%%]\n1***2%%%3");
			Assert.That(6, Is.EqualTo(result));
		}

		[SetUp]
		public void Mysetup()
		{
			
		}

		[Test]
		[TestCase("1,2", 3)]
		[TestCase("1,2,3,4,5,6", 21)]
		[TestCase("//;\n1;2", 3)]
		public void Given_Expect_DATADRIVEN(string input, int expected)
		{
			int result = sut.Add(input);
			Assert.That(expected, Is.EqualTo(result));
		}

		[Test]
		public void Unit_Scenario_Expectation()
		{
			Assert.That("Peter Gfader", Is.StringContaining("Peter"));

		}
	}

	//public class StubMANUAL : IAmAMock
	//{
		
	//}
}
