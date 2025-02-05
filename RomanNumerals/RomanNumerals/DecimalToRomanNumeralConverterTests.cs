namespace RomanNumerals;

    
public class DecimalToRomanNumeralConverterTests
{

    IDecimalValidator decimalValidator;
    DecimalToRomanNumeralConverter decimalToRomanConverter;

    public DecimalToRomanNumeralConverterTests()
    {

        decimalValidator = new InputValidator();
        decimalToRomanConverter = new DecimalToRomanNumeralConverter(decimalValidator);

    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void GivenNegativeorZeroDecimal_ThenThrowException(int decimalNumber)
    {
        // Act
        Action result = () => decimalToRomanConverter.Convert(decimalNumber);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("Cannot convert negative decimals to roman numerals.", exception.Message);
    }

    [Theory]
    [InlineData(3000)]
    [InlineData(3001)]
    public void GivenDecimalLargerThan2999_ThenThrowException(int decimalNumber)
    {
        // Act
        var result = () => decimalToRomanConverter.Convert(decimalNumber);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(result);
        Assert.Equal("Cannot convert decimals larger than 2999.", exception.Message);
    }



    [Theory]
    [InlineData(1, "I")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(40, "XL")]
    [InlineData(50, "L")]
    [InlineData(90, "XC")]
    [InlineData(100, "C")]
    [InlineData(400, "CD")]
    [InlineData(500, "D")]
    [InlineData(900, "CM")]
    [InlineData(1000, "M")]
    public void GivenDecimalCorrespondingToARomanBaseNumeral_ThenReturnRomanBaseNumeral(int decimalNumber, string expected)
    {
        // Act
        var result = decimalToRomanConverter.Convert(decimalNumber);
            
        // Assert
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(2000, "MM")]
    public void GivenDecimalResultingInRepetitiveRomanNumerals_ThenReturnRomanNumeral(int decimalNumber, string expected)
    {
        // Act
        var result = decimalToRomanConverter.Convert(decimalNumber);

        // Assert
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(90, "XC")]
    [InlineData(1999, "MCMXCIX")]
    [InlineData(2444, "MMCDXLIV")]
    public void GivenDecimal_ThenReturnRomanNumeral(int decimalNumber, string expected)
    {
        // Act
        var result = decimalToRomanConverter.Convert(decimalNumber);

        // Assert
        Assert.Equal(expected, result);
    }



}
