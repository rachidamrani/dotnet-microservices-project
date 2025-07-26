namespace eCommerce.Core.DTO;

public record AuthenticationReponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success);