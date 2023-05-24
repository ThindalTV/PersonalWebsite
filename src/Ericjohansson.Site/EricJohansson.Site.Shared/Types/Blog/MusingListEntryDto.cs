namespace EricJohansson.Site.Shared.Types.Blog;
public record MusingListEntryDto(
    string Id,
    DateOnly Posted,
    string Slug,
    string? ImageUrl,
    string Title,
    string Summary
    );
