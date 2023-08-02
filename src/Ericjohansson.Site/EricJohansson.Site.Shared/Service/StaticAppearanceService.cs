using EricJohansson.Site.Shared.Interfaces.Schedule;
using EricJohansson.Site.Shared.Types.Schedule;
using System.Runtime.CompilerServices;

namespace EricJohansson.Site.Shared.Service;
public class StaticAppearanceService : IAppearanceService
{
    public Task<AppearanceDto?> GetAppearanceAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<AppearanceDto> GetAppearancesAsync(int year, int month, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async IAsyncEnumerable<AppearanceDto> GetNextMonthsAppearances([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var endDate = DateTime.Now.AddMonths(1);
        var tuesdayOffset = DateTime.Now.DayOfWeek - DayOfWeek.Tuesday;

        var currentDate = DateTime.Now.AddDays(-tuesdayOffset);
        bool includeTime = true;
        int apperanceType = 1;
        while(currentDate < endDate) 
        {
            if(cancellationToken.IsCancellationRequested)
            {
                yield break;
            }
            Thread.Sleep(1000);


            yield return new AppearanceDto((currentDate.Date + new TimeSpan(19, 30, 00)).ToUniversalTime(), includeTime, null, "Twitch", (AppearanceType)apperanceType, "Streaming");

            currentDate = currentDate.AddDays(7);
            includeTime = !includeTime;
            apperanceType++;
            if (apperanceType > 3)
                apperanceType = 1;
        }

        
    }
}
