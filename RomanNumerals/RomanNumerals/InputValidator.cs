
namespace RomanNumerals
{
    public interface IRomanNumeralValidator
    {
        void NumeralIsLegal(string romanNumeral);
    }
    public interface IDecimalValidator
    {
        void DecimalIsLegal(int decimalNumber);
    }
    internal class InputValidator : IRomanNumeralValidator, IDecimalValidator
    {

        public void NumeralIsLegal(string romanNumeral)
        {
            // Missing cases:
            // Two smaller numerals in front of a larger
            // I is in front of L, C, D, M
            // X is in front of D, M


            if (string.IsNullOrEmpty(romanNumeral))
            {
                throw new ArgumentException("Roman numeral can not be empty.");
            }

            if (romanNumeral.Count(c => c == 'V') > 1 || 
                romanNumeral.Count(c => c == 'L') > 1 ||
                romanNumeral.Count(c => c == 'D') > 1)
            {
                throw new ArgumentException("V, L and D cannot be repeated.");
            }
            if (HasMoreThanThreeConsecutiveLetters(romanNumeral)) {
                throw new ArgumentException("Numerals cannot appear more than 3 times in a row.");
            }

        }


        public void DecimalIsLegal(int decimalNumber)
        {
            if (decimalNumber <= 0)
            {
                throw new ArgumentException("Cannot convert negative decimals to roman numerals.");
            }
            if (decimalNumber > 2999)
            {
                throw new ArgumentException("Cannot convert decimals larger than 2999.");
            }
        }

        private bool HasMoreThanThreeConsecutiveLetters(string romanNumeral)
        {
            for (int i = 0; i < romanNumeral.Length - 3; i++)
            {
                // Check if the current character is the same as the next three characters
                if (romanNumeral[i] == romanNumeral[i + 1] && 
                    romanNumeral[i] == romanNumeral[i + 2] && 
                    romanNumeral[i] == romanNumeral[i + 3])
                {
                    return true;
                }
            }
            return false;
        }
    }
}