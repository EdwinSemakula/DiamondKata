using System.Text.RegularExpressions;
using Diamond.Services.Interfaces;

namespace Diamond.Services.Validators;

public class DiamondRequestValidation : IDiamondRequestValidation
{
    public bool ValidateInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Please enter a character from A to Z");
            return false;
        }

        if (input.Length > 1)
        {
            Console.WriteLine("Please enter only one character");
            return false;
        }

        if (IsLetter(input))
            return true;

        Console.WriteLine("Input must be a character from A to Z");
        return false;

    }

    private bool IsLetter(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }
}