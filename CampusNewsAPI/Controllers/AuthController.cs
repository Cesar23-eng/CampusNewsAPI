using CampusNewsAPI.Data;
using CampusNewsAPI.Models;
using CampusNewsAPI.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CampusNewsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email))
            return BadRequest(new { message = "El email ya está registrado." });

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(new { message = "Usuario registrado correctamente." });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null || user.PasswordHash != request.Password)
            return Unauthorized(new { message = "Credenciales inválidas." });

        var token = _tokenService.CreateToken(user);
        return Ok(new { token });
    }
}