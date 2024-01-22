using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Models;

public class ContactMessage
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [JsonPropertyName("email")]
    public string FromEmail { get; set; } = default!;

    [Required]
    [JsonPropertyName("name")]
    public string FromName { get; set; } = string.Empty;

    [JsonPropertyName("createdOn")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [Required]
    [JsonPropertyName("content")]
    public string Body { get; set; } = default!;
}
