using Ericjohansson.Site.Client.Shared;
using Microsoft.AspNetCore.Components;

namespace Ericjohansson.Site.Client.Components.Layout;

public class LayoutSetter : ComponentBase
{
    [CascadingParameter]
    public MainLayout MainLayout { get; set; } = null!;

    [Parameter]
    public RenderFragment? HeaderContent { get; set; }


    protected override void OnInitialized()
    {
        MainLayout.SetHeader(HeaderContent);
        base.OnInitialized();
    }

}