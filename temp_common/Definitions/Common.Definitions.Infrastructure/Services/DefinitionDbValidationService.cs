
using System.Text.Json;
using Arfware.ArfBlocks.Core.Exceptions;
using Common.Definitions.Domain.Errors;
using Common.Services.ErrorCodeGenerator;
using Microsoft.EntityFrameworkCore;

namespace Common.Definitions.Infrastructure.Services;


public class DefinitionDbValidationService
{
    private readonly DefinitionDbContext _dbContext;

    public DefinitionDbValidationService(DefinitionDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task ValidateRoleExist(string roleName)
    {
        // Get
        var authorizedModuleExistById = await _dbContext.AppRoles.AnyAsync(d => d.Name.ToLower() == roleName.ToLower());

        // Check
        if (authorizedModuleExistById)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.RoleErrors.NameValid));
    }

    public async Task ValidateRoleExist(Guid roleId)
    {
        var roleExist = await _dbContext.AppRoles.AnyAsync(d => d.Id == roleId);

        if (!roleExist)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.RoleErrors.IdValid));
    }


    public async Task ValidateUserByUserNameExist(string userName)
    {
        // Get
        var authorizedModuleExistById = await _dbContext.AppUsers.AnyAsync(d => d.UserName.ToLower() == userName.ToLower());

        // Check
        if (authorizedModuleExistById)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNameValid));
    }

    public async Task ValidateUserByEmailExist(string email)
    {
        // Get
        var authorizedModuleExistById = await _dbContext.AppUsers.AnyAsync(d => d.Email.ToLower() == email.ToLower());

        // Check
        if (authorizedModuleExistById)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.EmailValid));
    }

    public async Task<string> ValidateGoogleToken(string token)
    {
        using var httpClient = new HttpClient();

        // Google'ın token info endpoint'i
        var requestUri = $"https://oauth2.googleapis.com/tokeninfo?id_token={token}";
        var response = await httpClient.GetAsync(requestUri);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var payload = JsonSerializer.Deserialize<GoogleTokenPayload>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        // Burada client_id kontrolü opsiyonel ama önerilir
        if (payload.Aud != "YOUR_GOOGLE_CLIENT_ID")
            return null;

        return payload.Sub; // Google User ID (benzersiz kimlik)
    }
    public async Task<string> ValidateAppleToken(string token)
    {
        using var httpClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://appleid.apple.com/auth/token"),
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "client_id", "YOUR_APPLE_CLIENT_ID" },
            { "client_secret", "YOUR_APPLE_CLIENT_SECRET" },
            { "grant_type", "authorization_code" },
            { "code", token }
        })
        };

        var response = await httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var tokenData = JsonSerializer.Deserialize<AppleTokenPayload>(content);

        // sub (unique identifier) alanını döndür
        return tokenData?.IdTokenPayload?.Sub;
    }

}