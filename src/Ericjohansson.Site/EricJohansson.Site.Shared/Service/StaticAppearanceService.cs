using EricJohansson.Site.Shared.Interfaces.Schedule;
using EricJohansson.Site.Shared.Types.Schedule;
using System.Runtime.CompilerServices;

namespace EricJohansson.Site.Shared.Service;
public class StaticAppearanceService : IAppearanceService
{
    public async Task<AppearanceDto?> GetAppearanceAsync(string id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return new AppearanceDto(
            Time: DateTime.Now,
            IncludesTime: true,
            ImageUrl: null,
            Location: "Mock Location",
            Url: "https://www.example.com/",
            UrlText: "Example",
            AppearanceType: AppearanceType.Other,
            Description: "Mock Description");
    }

    public async IAsyncEnumerable<AppearanceDto> GetAppearancesAsync(int year, int month, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        yield return new AppearanceDto(
            Time: DateTime.Now,
            IncludesTime: true,
            ImageUrl: null,
            Location: "Mock Location",
            Url: "https://www.example.com/",
            UrlText: "Example",
            AppearanceType: AppearanceType.Other,
            Description: "Mock Description");
    }

    public async IAsyncEnumerable<AppearanceDto> GetNextMonthsAppearances([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var endDate = DateTime.Now.AddMonths(1);
        var tuesdayOffset = DateTime.Now.DayOfWeek - DayOfWeek.Tuesday;

        var currentDate = DateTime.Now.AddDays(-tuesdayOffset);
        bool includeTime = true;
        int apperanceType = 1;
        var streamDesc = $@"
Every tuesday at 19:30 CET, you can find me streaming
C# development on Twitch.";

        var streamingAppearance = new AppearanceDto(
             Time: DateTime.Now,
             IncludesTime: includeTime,
             ImageUrl: null,
             Location: "Twitch",
             Url: "https://www.twitch.tv/thindal",
             UrlText: "Twitch",
             AppearanceType: AppearanceType.Streaming,
             Description: streamDesc);
        while (currentDate < endDate)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            if (apperanceType == 1) // Streaming
            {
                yield return streamingAppearance with
                {
                    Time = (currentDate.Date + new TimeSpan(19, 30, 00)).ToUniversalTime()
                };
            }
            else // Everything else
            {
                yield return new AppearanceDto(
                    Time: (currentDate.Date + new TimeSpan(19, 30, 00)).ToUniversalTime(),
                    IncludesTime: includeTime,
                    ImageUrl: null,
                    Location: ((AppearanceType)apperanceType).ToString(),
                    Url: apperanceType < 3 ? "https://www.google.com/" : null,
                    UrlText: apperanceType < 2 ? "Google" : null,
                    AppearanceType: (AppearanceType)apperanceType,
                    Description: ((AppearanceType)apperanceType).ToString());
            }

            currentDate = currentDate.AddDays(7);
            includeTime = !includeTime;
            apperanceType++;
            if (apperanceType > 5)
                apperanceType = 1;
        }


    }
}
