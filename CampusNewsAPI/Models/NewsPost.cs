namespace CampuesNewsAPI.Models;

public class News
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Condition { get; set; }
    public string Location { get; set; }
    public string PaymentMethod { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string WhatsAppLink { get; set; }
    public string ImageUrl { get; set; } // Ruta o URL de la imagen subida
    public DateTime PublishDate { get; set; }
    public string Author { get; set; }
}