namespace EricJohansson.Site.Shared.Types.Schedule;
public record Appearance(DateTime Time, bool IncludesTime, string? ImageUrl, string Location, AppearanceType AppearanceType, string Description);

public enum AppearanceType
{
    Streaming,
    Speaking,
    Other
}