using EricJohansson.Site.Shared.Types.Schedule;

namespace EricJohansson.Site.Shared.Interfaces.Schedule;
public interface IAppearanceService
{
    IAsyncEnumerable<AppearanceDto> GetNextMonthsAppearances(CancellationToken cancellationToken);
    IAsyncEnumerable<AppearanceDto> GetAppearancesAsync(int year, int month, CancellationToken cancellationToken);
    Task<AppearanceDto?> GetAppearanceAsync(string id, CancellationToken cancellationToken);
}
