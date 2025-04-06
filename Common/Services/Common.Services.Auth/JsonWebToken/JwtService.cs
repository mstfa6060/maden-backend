using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Common.Definitions.Base.Enums;
using Common.Definitions.Domain.Entities;

namespace Common.Services.Auth.JsonWebToken;

public class JwtService : IJwtService
{
	public static string Secret = "5V-3TKad=*+9qFRp!%Ee7?a5#qQm7t9rHe%Ejg2*J4@EZ!@U02";
	public static string Audience = "iam.toprak.tkholding.com.tr";
	private readonly int WebExpirationDayCount = 7;
	private readonly int MobileExpirationDayCount = 7;
	private readonly int ExpirationMinutesForTempJwt = 5;

	public string GenerateJwt(Guid userId, string userName, string displayName, ClientPlatforms platform, DateTime expiresAt, UserSources userSource)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(JwtService.Secret);


		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Audience = JwtService.Audience,
			IssuedAt = DateTime.Now,
			Subject = new ClaimsIdentity(new Claim[]
				{
										new Claim("nameid", userId.ToString()),
										new Claim("given_name", userName),
										new Claim("unique_name", displayName),
										new Claim("platform", $"{((decimal)platform)}"),
										new Claim("userSource", $"{((decimal)userSource)}"),
				}),
			Expires = expiresAt,
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}

	public int GetExpirationDayCount()
	{
		return this.WebExpirationDayCount;
	}
}