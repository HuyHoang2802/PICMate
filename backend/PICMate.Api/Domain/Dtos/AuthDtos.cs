namespace PICMate.Api.Domain.Dtos;

public record LoginRequest(string Email, string Password);
public record UserSession(string Name, string Email, string Role, string Avatar, string Redirect);
public record LoginResponse(UserSession User, string Redirect, string Token);
