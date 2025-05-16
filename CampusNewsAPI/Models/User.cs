using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampusNewsAPI.Models;

public enum Role { Admin = 0, User = 1 }

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    [Required]
    public Role Role { get; set; } = Role.User;

    [JsonIgnore]
    public List<Post> NewsPosts { get; set; } = new();
}