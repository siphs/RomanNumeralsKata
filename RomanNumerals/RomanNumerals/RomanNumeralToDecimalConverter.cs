
namespace RomanNumerals;

public interface IRomanToDecimalConverter
{
    int Convert(string number);
}

public class RomanToDecimalConverter: IRomanToDecimalConverter
{
    int[] decimals = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
    string[] romanBaseNumerals = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};

    private readonly IRomanNumeralValidator romanValidator;
    public RomanToDecimalConverter(IRomanNumeralValidator validator)
    {
        romanValidator = validator;
    }

    public int Convert(string romanNumeral)
    {
        InputValidator validator = new();
        validator.NumeralIsLegal(romanNumeral);

        int result = 0;
        int prevRomanIndex = romanBaseNumerals.Length;

        foreach (char letter in romanNumeral.ToCharArray())
        {
            int currentRomanIndex = Array.IndexOf(romanBaseNumerals, letter.ToString());
                
            if (currentRomanIndex > prevRomanIndex)
            {
                string subtractiveNumeral = romanBaseNumerals[prevRomanIndex].ToString() + romanBaseNumerals[currentRomanIndex].ToString();
                currentRomanIndex = Array.IndexOf(romanBaseNumerals, subtractiveNumeral);

                result = result - decimals[prevRomanIndex] + decimals[currentRomanIndex]; // er den her ulaeselig?

            }
            else
            {
                prevRomanIndex = currentRomanIndex;
                result += decimals[currentRomanIndex];

            }

        }

        return result;
            
    }
}
