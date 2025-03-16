using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BinaryApp.Pages;

public partial class Converter : ComponentBase
{
    private string _convertedText = string.Empty;
    private string _textToConvert = string.Empty;

    /// <summary>
    ///     Converts the text in `_textToConvert` to its binary representation and stores it in `_convertedText`.
    ///     Each character is converted to an 8-bit binary string and separated by spaces.
    /// </summary>
    private void ConvertToBinary()
    {
        if (string.IsNullOrWhiteSpace(_textToConvert))
        {
            _convertedText = string.Empty;
            return;
        }

        _convertedText = string.Join(" ", _textToConvert.Select(
            c => Convert.ToString(c, 2).PadLeft(8, '0'))
        );
    }
}