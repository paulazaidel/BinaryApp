using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Caching.Memory;

namespace BinaryApp.Pages;

public partial class Converter : ComponentBase
{
    private readonly IMemoryCache _cache;
    private string _convertedText = string.Empty;
    private string _textToConvert = string.Empty;

    public Converter(IMemoryCache cache)
    {
        _cache = cache;
    }
    
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
        
        List<(string, string)> historical;
        if (_cache.TryGetValue("convertedText", out List<(string, string)>? cachedHistorical))
        {
            historical = cachedHistorical;
        }
        else
        {
            historical = new List<(string, string)>();
        }

        historical.Add((_textToConvert, _convertedText));
        _cache.Set("convertedText", historical);
    }
}