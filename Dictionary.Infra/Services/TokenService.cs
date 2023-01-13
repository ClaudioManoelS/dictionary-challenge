using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using Dictionary.Domain.DictionaryContext.Entities;
using Dictionary.Infra.Interfaces.Services;

namespace Dictionary.Infra.Services;

public class TokenService : ITokenService
{

  private IConfiguration _config;
  public TokenService(IConfiguration config)
  {
    _config = config;
  }
  public string GenerateToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = GetKey();
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[]{
        new Claim(ClaimTypes.Name, user.Name!),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
      }),
      Expires = DateTime.UtcNow.AddMinutes(5),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
  }

  public byte[] GetKey()
  {
    return Encoding.ASCII.GetBytes(_config.GetSection("Jwt").GetValue<string>("secret"));
  }
}