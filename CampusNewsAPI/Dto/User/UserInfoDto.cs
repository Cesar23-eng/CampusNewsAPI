using CampusNewsAPI.Models;

namespace CampusNewsAPI.Dto.User;

public class UserInfoDto
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
}