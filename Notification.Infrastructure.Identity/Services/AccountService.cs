using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Notification.Application.Contracts;
using Notification.Application.Dtos;
using Notification.Application.Wrappers;
using Notification.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Notification.Infrastructure.Identity.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtSetting _jwtSettings;

    public AccountService(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
         IOptionsMonitor<JwtSetting> jwtSettings)
    {
        _jwtSettings = jwtSettings.CurrentValue;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<LoginResponseDto> Login(LoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Email);
        if (user is null)
            return null;

        var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, lockoutOnFailure: false);
        if (!result.Succeeded)
            return null;

        var userRoles = await _userManager.GetRolesAsync(user);
        if (userRoles is null)
            throw new Exception();

        JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
        LoginResponseDto response = new LoginResponseDto();
        response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        response.Username = user.Email;
        var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        return response;
    }

    public async Task<bool> Register(RegisterDto dto)
    {
        var user = new IdentityUser
        {
            Email = dto.Email,
            UserName = dto.Email,
            EmailConfirmed = true
        };
        var userFromDb = await _userManager.Users.Where(x => x.Email == dto.Email).FirstOrDefaultAsync();
        if (userFromDb is null)
        {
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "USER");
                await _userManager.UpdateAsync(user);
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    private async Task<JwtSecurityToken> GenerateJWToken(IdentityUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }

        string ipAddress = "";

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("uid", user.Id),
            new Claim("ip", ipAddress)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
        issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.expireInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }

}
