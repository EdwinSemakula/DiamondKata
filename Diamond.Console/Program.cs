using Diamond.Services;
using Diamond.Services.Interfaces;
using Diamond.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDiamondCreationService, DiamondCreationService>()
                .AddSingleton<IDiamondRequestValidation, DiamondRequestValidation>()
                .BuildServiceProvider();

            
            var diamondRequestValidationService = serviceProvider.GetService<IDiamondRequestValidation>();
            var diamondCreationService = serviceProvider.GetService<IDiamondCreationService>();

            string userInput;
            do
            {
                System.Console.WriteLine("Please enter a letter of the alphabet:");
                userInput = System.Console.ReadLine() ?? "";
            } while (!diamondRequestValidationService.ValidateInput(userInput));

            if (diamondRequestValidationService.ValidateInput(userInput))
            {
                var validInput = userInput.ToUpper()[0];
                var diamond = diamondCreationService.CreateDiamond(validInput);

                foreach (var character in diamond)
                {
                    System.Console.WriteLine(character);
                }
            }
        }
    }
}