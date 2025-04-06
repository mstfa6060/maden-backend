using Common.Definitions.Base.Enums;
using Common.Definitions.Domain.Entities;

namespace Common.Services.Auth.JsonWebToken;

public interface IJwtService
{
	string GenerateJwt(Guid userId, string userName, string displayName, ClientPlatforms platform, DateTime expiresAt, UserSources userSource);
	int GetExpirationDayCount();

}