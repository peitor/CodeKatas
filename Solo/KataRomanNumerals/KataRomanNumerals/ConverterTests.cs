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
		[InlineData(19, "XIX")]
		[InlineData(44, "XLIV")]
		[InlineData(47, "XLVII")]
		[InlineData(48, "XLVIII")]
		[InlineData(49, "IL")]
		[InlineData(50, "L")]
		[InlineData(51, "LI")]
		[InlineData(60, "LX")]
		[InlineData(70, "LXX")]
		[InlineData(80, "LXXX")]
    	public void ConvertData(int input, string expected)
		{
			Assert.Equal(expected, converter.Convert(input));
		}
		

    }
}
