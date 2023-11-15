
using Microsoft.AspNetCore.Components;

namespace EricJohansson.Site.Shared.Support;

public class CancellableComponentBase : ComponentBase, IDisposable
{
    private readonly CancellationTokenSource _cancellationSource = new();
    protected CancellationToken CancellationToken => _cancellationSource.Token;
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _cancellationSource.Cancel();
        _cancellationSource.Dispose();
    }
}
