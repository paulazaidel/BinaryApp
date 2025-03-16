using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;

namespace BinaryApp.Pages;

public partial class History : ComponentBase
{
    [Inject] private IMemoryCache _cache { get; set; } = default!;
    private (string, string)[] _historical = Array.Empty<(string, string)>();
    
    protected override void OnInitialized()
    {
        if (_cache.TryGetValue("convertedText", out List<(string, string)>? cachedHistorical))
        {
            _historical = cachedHistorical.ToArray();
        }
    }
}