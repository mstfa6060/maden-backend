using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Common.Definitions.Base.Enums;
using Arfware.ArfBlocks.Core;
using Common.Definitions.Domain.Models;
using Common.Services.Environment;
using Common.Definitions.Domain.Entities;

namespace Common.Services.Auth.CurrentUser;

public class CurrentUserService
{
    private CurrentUserModel _currentUser;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(ArfBlocksDependencyProvider dependencyProvider)
    {
        _httpContextAccessor = dependencyProvider.GetInstance<IHttpContextAccessor>();
        var environmentService = dependencyProvider.GetInstance<EnvironmentService>();

        if (environmentService.Environment == CustomEnvironments.Test)
        {
            this._currentUser = dependencyProvider.GetInstance<CurrentUserModel>();
        }
        else
        {
            try
            {
                var authorizationValue = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
                if (!string.IsNullOrEmpty(authorizationValue))
                {
                    string jwtInput = authorizationValue.Split(' ')[1];
                    this._currentUser = this.ParseJwt(jwtInput);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CurrentUserService initialization error: {ex.Message}");
            }
        }
    }

    private CurrentUserModel ParseJwt(string jwtInput)
    {
        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            if (!jwtHandler.CanReadToken(jwtInput)) throw new Exception("Invalid JWT format.");

            var token = jwtHandler.ReadJwtToken(jwtInput);

            return new CurrentUserModel
            {
                Id = Guid.Parse(token.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value ?? Guid.Empty.ToString()),
                Username = token.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value,
                DisplayName = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value,
                TenantId = Guid.Parse(token.Claims.FirstOrDefault(c => c.Type == "tenantId")?.Value ?? Guid.Empty.ToString()),
                Platform = (ClientPlatforms)Convert.ToInt32(token.Claims.FirstOrDefault(c => c.Type == "platform")?.Value ?? "3"),
                UserSource = (UserSources)Convert.ToInt32(token.Claims.FirstOrDefault(c => c.Type == "userSource")?.Value ?? "0")
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JWT Parsing Error: {ex.Message}");
            return null;
        }
    }

    public Guid GetCurrentUserId() => _currentUser?.Id ?? Guid.Empty;
    public Guid GetCompanyId() => _currentUser?.TenantId ?? Guid.Empty;
    public string GetCurrentUserDisplayName() => _currentUser?.DisplayName;
    public string GetCurrentUserUserName() => _currentUser?.Username;
    public ClientPlatforms GetCurrentUserPlatform() => _currentUser?.Platform ?? ClientPlatforms.Unknown;
    public UserSources GetCurrentUserSource() => _currentUser.UserSource;

    public IPAddress GetCurrentUserIp()
    {
        IPAddress remoteIpAddress = null;
        var forwardedFor = _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrEmpty(forwardedFor))
        {
            var ips = forwardedFor.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
            foreach (var ip in ips)
            {
                if (IPAddress.TryParse(ip, out var address) &&
                    (address.AddressFamily == AddressFamily.InterNetwork || address.AddressFamily == AddressFamily.InterNetworkV6))
                {
                    remoteIpAddress = address;
                    break;
                }
            }
        }
        else
        {
            remoteIpAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress;
        }

        return remoteIpAddress;
    }
}
