using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Api.Models;

public class ContactMessage
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [JsonPropertyName("email")]
    public string FromEmail { get; set; } = default!;

    [JsonPropertyName("name")]
    public string FromName { get; set; } = string.Empty;

    [JsonPropertyName("createdOn")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("content")]
    [Required]
    public string Body { get; set; } = default!;


}
