
namespace RomanNumerals;

public interface IDecimalToRomanConverter
{
    string Convert(int number);
}

public class DecimalToRomanNumeralConverter : IDecimalToRomanConverter
{
    int[] num = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
    string[] rom = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};

    private readonly IDecimalValidator decimalValidator;
    public DecimalToRomanNumeralConverter(IDecimalValidator validator)
    {
        decimalValidator = validator;
    }

    public string Convert(int decimalNumber)
    {
        decimalValidator.DecimalIsLegal(decimalNumber);

        int numberLeft = decimalNumber;
        string romanResult = "";
        int currentDigitIndex = rom.Length-1;

        while (numberLeft > 0)
        {
            int largestNumeral = num[currentDigitIndex];
            int repetitions = numberLeft / largestNumeral;

            for(int i = 0; i<repetitions; i++)
            {
                romanResult += rom[currentDigitIndex];
            }

            numberLeft = numberLeft % largestNumeral;
            currentDigitIndex -= 1;
                
        }

        return romanResult;
            
    }

}



