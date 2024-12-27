using EcommerceApi.Models.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceApi.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    private readonly SymmetricSecurityKey _key =
        new(Encoding.UTF8.GetBytes(config["Jwt:SigningKey"]!));

    public string CreateToken(AppUser user)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Email, user.Email!),
        new(JwtRegisteredClaimNames.GivenName, user.UserName!)
        ];

        SigningCredentials credentials =
            new(_key, SecurityAlgorithms.HmacSha512Signature);
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credentials,
            Issuer = config["Jwt:Issuer"]!,
            Audience = config["Jwt:Audience"]!
        };

        JwtSecurityTokenHandler tokenHandler = new();
        return tokenHandler.WriteToken(tokenHandler
            .CreateToken(tokenDescriptor));
    }
}
