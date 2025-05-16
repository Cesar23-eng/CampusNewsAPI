using CampusNewsAPI.Models;

namespace CampusNewsAPI.Dto.NewPost;

public class PostDetailDto
{
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public Category Category { get; set; }
    public string Condition { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string PaymentMethod { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string WhatsAppLink { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}