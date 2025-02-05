namespace RomanNumerals;

public class RomanNumeralToDecimalConverterTests
{
    IRomanNumeralValidator romanValidator;
    RomanToDecimalConverter romanToDecimalConverter;


    public RomanNumeralToDecimalConverterTests()
    {

        romanValidator = new InputValidator();
        romanToDecimalConverter = new RomanToDecimalConverter(romanValidator);

    }


    [Theory]
    [InlineData("")]
    public void GivenEmptyNumeral_ThenThrowException(string romanNumeral)
    {
        // Act
        Action result = () => romanToDecimalConverter.Convert(romanNumeral);


        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("Roman numeral can not be empty.", exception.Message);
    }

    [Theory]
    [InlineData("VV")]
    [InlineData("LL")]
    [InlineData("DD")]

    public void GivenVLDRepeated_ThenThrowException(string romanNumeral)
    {
        // Act
        Action result = () => romanToDecimalConverter.Convert(romanNumeral);


        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("V, L and D cannot be repeated.", exception.Message);
    }



    [Theory]
    [InlineData("IIII")]
    [InlineData("IIIII")]

    public void GivenANumeralWithMoreThan3ConsecutiveLetters_ThenThrowException(string romanNumeral)
    {
        // Act
        Action result = () => romanToDecimalConverter.Convert(romanNumeral);


        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("Numerals cannot appear more than 3 times in a row.", exception.Message);
    }


    /* Tests for missing cases
    [Theory]
    [InlineData("IL")]
    [InlineData("IC")]
    [InlineData("ID")]
    [InlineData("IM")]
    public void GivenRomanNumeralWhereIIsBeforeLCDM_ThenThrowException(string romanNumeral)
    {
        // Act
        var result = () => decimalToRomanConverter.Convert(decimalNumber);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("'I' can only come in front of V and X.", exception.Message);
    }

    [Theory]
    [InlineData("XD")]
    [InlineData("XM")]
    public void GivenRomanNumeralWhereXIsBeforeDM_ThenThrowException(string romanNumeral)
    {
        // Act
        var result = () => decimalToRomanConverter.Convert(decimalNumber);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("'X' can only come in front of L and C.", exception.Message);
    }
    
     */

    [Theory]
    [InlineData("I",1)]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("L", 50)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    public void GivenRomanBaseNumeral_ThenReturnCorrespondingDecimal(string romanNumeral, int expected)
    {
        // Act
        var result = romanToDecimalConverter.Convert(romanNumeral);

        // Assert
        Assert.Equal(expected, result);

    }


    [Theory]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XL", 40)]
    [InlineData("XC", 90)]
    [InlineData("CD", 400)]
    [InlineData("CM", 900)]
    public void GivenSubtractiveRomanBaseNumeral_ThenReturnCorrespondingDecimal(string romanNumeral, int expected)
    {
        // Act
        var result = romanToDecimalConverter.Convert(romanNumeral);

        // Assert
        Assert.Equal(expected, result);

    }

    [Theory]
    [InlineData("II", 2)]
    [InlineData("III", 3)]
    [InlineData("CC", 200)]
    [InlineData("CCC", 300)]
    [InlineData("MMM", 3000)]
    public void GivenRomanNumeralWithConsecutiveLetters_ThenReturnCorrespondingDecimal(string romanNumeral, int expected)
    {
        // Act
        var result = romanToDecimalConverter.Convert(romanNumeral);

        // Assert
        Assert.Equal(expected, result);

    }


    [Theory]
    [InlineData("XC", 90)]
    [InlineData("MCMXCIX", 1999)]
    [InlineData("MMCDXLIV", 2444)]
    public void GivenRomanNumeral_ThenReturnCorrespondingDecimal(string romanNumeral, int expected)
    {

        // Act
        var result = romanToDecimalConverter.Convert(romanNumeral);

        // Assert
        Assert.Equal(expected, result);

    }

}
