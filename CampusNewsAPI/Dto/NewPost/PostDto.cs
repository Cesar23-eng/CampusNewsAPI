using CampusNewsAPI.Models;

namespace CampusNewsAPI.Dto.NewPost;

class PostDto
{
    public int Id { get; set; }
    public string title { get; set; }
    public double price { get; set; }
    public string author { get; set; }
    public string category { get; set; }
    public string condition { get; set; }
    public string location { get; set; }
    public string paymentMethod { get; set; }
    public string description { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
    public string whatsAppLink { get; set; }
    public string imageUrl { get; set; }
    public DateTime publishdate { get; set; }
}