using Xunit;
using Xunit.Extensions;

namespace KataRomanNumerals
{
	public class ConverterTests
    {
		readonly RomanNumerals converter = new RomanNumerals();
			
		[Theory]
		[InlineData(1, "I")]
		[InlineData(2, "II")]
		[InlineData(3, "III")]
		[InlineData(4, "IV")]
		[InlineData(5, "V")]
		[InlineData(6, "VI")]
		[InlineData(7, "VII")]
		[InlineData(8, "VIII")]
		[InlineData(9, "IX")]
		[InlineData(10, "X")]
		[InlineData(11, "XI")]
		[InlineData(15, "XV")]
		[InlineData(18, "XVIII")]
		[InlineData(19, "XIX")]
		[InlineData(20, "XX")]
		[InlineData(30, "XXX")]
		[InlineData(31, "XXXI")]
		[InlineData(44, "XLIV")]
		[InlineData(47, "XLVII")]
		[InlineData(48, "XLVIII")]
		[InlineData(49, "IL")]
		[InlineData(50, "L")]
		[InlineData(51, "LI")]
		[InlineData(60, "LX")]
		[InlineData(70, "LXX")]
		[InlineData(79, "LXXIX")]
		[InlineData(80, "LXXX")]
		[InlineData(84, "LXXXIV")]
		[InlineData(90, "XC")]
		[InlineData(400, "CD")]
		[InlineData(401, "CDI")]
		[InlineData(448, "CDXLVIII")]
		[InlineData(500, "D")]
		[InlineData(900, "CM")]
		[InlineData(1999, "MCMXCIX")]
		[InlineData(2008, "MMVIII")]
		public void ConvertData(int input, string expected)
		{
			Assert.Equal(expected, converter.Convert(input));
		}
		

    }
}
