using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.BL.Dtos.StatusCode;
using Project.BL.Dtos.Users;
using Project.BL.Mappers.Mapper;
using Project.BL.Services.CartService;
using Project.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.BL.Services.AuthService;
public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManger;
    private readonly ICartService _cartservice;

    public AuthService(IConfiguration configuration, IMapper mapper, UserManager<User> userManger,ICartService cartservice)
    {
         _configuration = configuration;
        _mapper = mapper;
        _userManger = userManger;
        _cartservice = cartservice;
    }
    private string generateToken(User user)
    {
        List<Claim> userClaims = new()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Name,user.FullName)
        };
        var key = _configuration.GetSection("jwtSecretKey").Value;
        var keyInBytes = Encoding.ASCII.GetBytes(key);
        var symitricKey = new SymmetricSecurityKey(keyInBytes);
        var signingCredentials = new SigningCredentials(symitricKey, SecurityAlgorithms.HmacSha256Signature);
        var expireDate = DateTime.UtcNow.AddDays(1);
        var jwt = new JwtSecurityToken(
            claims: userClaims,
            expires: expireDate,
            signingCredentials: signingCredentials);
        var Token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return Token;
    }

    public async Task<StatusCodeDTO> Login(LoginDTO login)
    {
        User? user = await _userManger.FindByEmailAsync(login.Email);

        if (user == null)
            return new StatusCodeDTO(statuscode.NotFound,"email or password is incorrect");

        string Token = generateToken(user);
        return new StatusCodeDTO(statuscode.Ok, null, Token);
    }

    public async Task<StatusCodeDTO> registration(SignupDTO user)
    {
        User? isUserExiest = await _userManger.FindByEmailAsync(user.Email);
        if (isUserExiest != null)
            return new StatusCodeDTO(statuscode.BadRequest,"this email is already exiest");

        User? newUser = _mapper.user.SignToUser(user);
        var result = await _userManger.CreateAsync(newUser, user.password);
        string Token = generateToken(newUser);

        if (!result.Succeeded)
            return new StatusCodeDTO(statuscode.BadRequest, result.Errors.ToString());

        /* Assign a cart to the user */
        _cartservice.createCart(newUser.Id);

        return new StatusCodeDTO(statuscode.Ok,null,Token);
    }

} 
