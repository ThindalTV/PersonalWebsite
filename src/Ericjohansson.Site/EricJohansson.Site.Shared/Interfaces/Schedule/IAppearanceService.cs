using EricJohansson.Site.Shared.Types.Schedule;

namespace EricJohansson.Site.Shared.Interfaces.Schedule;
public interface IAppearanceService
{
    IAsyncEnumerable<Appearance> GetNextMonthsAppearances(CancellationToken cancellationToken);
    IAsyncEnumerable<Appearance> GetAppearancesAsync(int year, int month, CancellationToken cancellationToken);
    Task<Appearance?> GetAppearanceAsync(string id, CancellationToken cancellationToken);
}
