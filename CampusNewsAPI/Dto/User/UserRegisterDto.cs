using CampusNewsAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CampusNewsAPI.Dto.User;

public class UserRegisterDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required, MinLength(6)]
    public string Password { get; set; } = null!;

    public Role Role { get; set; } = Role.User;
}