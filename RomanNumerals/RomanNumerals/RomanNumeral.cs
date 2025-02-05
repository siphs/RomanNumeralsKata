
namespace RomanNumerals
{
    public class RomanNumeral
    {

        private readonly IRomanNumeralValidator romanValidator;


        public RomanNumeral(IRomanNumeralValidator validator)
        {
            romanValidator = validator;
        }

    }
}