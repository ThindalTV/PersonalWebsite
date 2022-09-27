using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricJohansson.Site.Shared.Blazor
{
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
}
