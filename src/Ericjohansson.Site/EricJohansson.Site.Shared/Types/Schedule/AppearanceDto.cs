namespace EricJohansson.Site.Shared.Types.Schedule;
public record AppearanceDto(DateTime Time, bool IncludesTime, string? ImageUrl, string Location, AppearanceType AppearanceType, string Description);

public enum AppearanceType
{
    Streaming = 1,
    Speaking = 2,
    Other = 3
}