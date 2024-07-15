using Diamond.Common;
using Diamond.Services.Interfaces;
using System.Text;

namespace Diamond.Services;

public class DiamondCreationService : IDiamondCreationService
{
    private char[] _alphabet;

    public string[] CreateDiamond(char input)
    {
        _alphabet = AlphabetArray.Alphabet;

        var inputIndex = Array.IndexOf(_alphabet, input);
        var diamondArraySize = (2 * inputIndex) + 1;
        var diamond = new string[diamondArraySize];

        for (var i = 0; i <= inputIndex; i++)
        {
            diamond[i] = CreateDiamondRow(i, inputIndex);

            if (i < inputIndex)
            {
                diamond[diamondArraySize - i - 1] = diamond[i];
            }
        }

        return diamond;
    }

    private string CreateDiamondRow(int rowIndex, int inputIndex)
    {
        var row = new StringBuilder();

        // add initial spaces
        for (int j = 0; j < inputIndex - rowIndex; j++)
        {
            row.Append(" ");
        }

        // add letter
        row.Append(_alphabet[rowIndex]);

        // add spaces between letters
        if (rowIndex > 0)
        {
            for (int j = 0; j < (rowIndex * 2) - 1; j++)
            {
                row.Append(" ");
            }

            // add letter
            row.Append(_alphabet[rowIndex]);
        }

        return row.ToString();
    }
}