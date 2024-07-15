using Diamond.Services;
using Diamond.Services.Interfaces;
using Diamond.Services.Validators;

namespace Diamond.Console
{
    public class Program
    {
        private static IDiamondCreationService _diamondService;
        private static IDiamondRequestValidation _diamondRequestValidation;
        public Program(IDiamondCreationService diamondCreationService,
            IDiamondRequestValidation diamondRequestValidation)
        {
            _diamondService = diamondCreationService;
            _diamondRequestValidation = diamondRequestValidation;
        }

        public static void Main(string[] args)
        {

            var diamondCreationService = new DiamondCreationService();
            var diamondRequestValidation = new DiamondRequestValidation();
            var program = new Program(diamondCreationService, diamondRequestValidation);

            string stringInput;

            do
            {
                System.Console.WriteLine("Please enter a letter of the alphabet:");
                stringInput = System.Console.ReadLine() ?? "";
            } while (!_diamondRequestValidation.ValidateInput(stringInput));

            if (_diamondRequestValidation.ValidateInput(stringInput))
            {
                var input = stringInput.ToUpper()[0];
                var diamond = _diamondService.CreateDiamond(input);

                foreach (var letter in diamond)
                {
                    System.Console.WriteLine(letter);
                }
            }
        }
    }
}