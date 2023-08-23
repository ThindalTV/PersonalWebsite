namespace EricJohansson.Site.Shared.Types.Schedule;
public record AppearanceDto(
DateTime Time,
bool IncludesTime,
string? ImageUrl,
string Location,
string? Url,
string? UrlText,
AppearanceType AppearanceType,
string Description);

public enum AppearanceType
{
    Streaming = 1,
    Speaking = 2,
    Appearance = 3,
    Attending = 4,
    Other = 5
}