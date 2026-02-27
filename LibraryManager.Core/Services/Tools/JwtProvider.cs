using System.Security.Claims;
using LibraryManager.Core.Interfaces.Tools;
using LibraryManager.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace LibraryManager.Core.Services.Tools;

public class JwtProvider(IConfiguration configuration) : IJwtProvider
{
  public string Generate(User user)
  {
    //definition des claims (infos contenues dans le badge)
    Claim[] claims =
    [
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.Email, user.Email),
      new Claim(ClaimTypes.Role, user.Role.ToString())
    ];
    //Recuperation cle secrete
    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
    
    //Identifiant de signature
    SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
    //Creation du token
    JwtSecurityToken token = new JwtSecurityToken(
      issuer: configuration["Jwt:Issuer"],
      audience: configuration["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddHours(2),
      signingCredentials: creds
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}