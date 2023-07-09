using EricJohansson.Site.Shared.Interfaces.Schedule;
using EricJohansson.Site.Shared.Types.Schedule;
using System.Runtime.CompilerServices;

namespace EricJohansson.Site.Shared.Service;
public class StaticAppearanceService : IAppearanceService
{
    public Task<Appearance?> GetAppearanceAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Appearance> GetAppearancesAsync(int year, int month, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async IAsyncEnumerable<Appearance> GetNextMonthsAppearances([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var endDate = DateTime.Now.AddMonths(1);
        var tuesdayOffset = DateTime.Now.DayOfWeek - DayOfWeek.Tuesday;

        var currentDate = DateTime.Now.AddDays(-tuesdayOffset);
        bool includeTime = true;
        while(currentDate < endDate) 
        {
            if(cancellationToken.IsCancellationRequested)
            {
                yield break;
            }
            yield return new Appearance((currentDate.Date + new TimeSpan(19, 30, 00)).ToUniversalTime(), includeTime, "https://www.vhv.rs/dpng/d/405-4055346_twitch-logo-png-transparent-background-twitch-logo-png.png", "Twitch", AppearanceType.Streaming, "Streaming");
            currentDate = currentDate.AddDays(7);
            includeTime = !includeTime;
        }

        
    }
}
