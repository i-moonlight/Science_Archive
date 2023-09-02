namespace ScienceArchive.Application.Dtos.User.Response;

/// <summary>
/// Response contract to get all authors request
/// </summary>
/// <param name="Authors">All authors</param>
public record GetAllAuthorsResponseDto(List<AuthorDto> Authors);