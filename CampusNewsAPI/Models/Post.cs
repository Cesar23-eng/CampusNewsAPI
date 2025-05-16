using System.ComponentModel.DataAnnotations;
using CampusNewsAPI.Models;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public double Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public string Condition { get; set; } = null!;

    [Required]
    public string Location { get; set; } = null!;

    [Required]
    public string PaymentMethod { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    public string WhatsAppLink { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; } = DateTime.UtcNow;

    public int AuthorId { get; set; }
    public User? Author { get; set; }
}