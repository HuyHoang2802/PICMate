namespace PICMate.Api.Domain.Responses;

public record LoginResultResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAtUtc, string TokenType, string Redirect, string Role, string Name, string Email, string Avatar);
public record RefreshRequest(string RefreshToken);
public record RefreshResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAtUtc, string TokenType);
