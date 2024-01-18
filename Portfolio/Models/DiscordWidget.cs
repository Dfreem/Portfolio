using System.Text.Json.Serialization;

namespace Portfolio.Models;

public class DiscordWidget
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
    public List<DiscordMember> Members { get; set; } = new();

    [JsonPropertyName("instant_invite")]
    public string InstantInvite { get; set; } = default!;

    [JsonPropertyName("presence_count")]
    public int PresenceCount { get; set; }
}

public class DiscordMember
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; } = default!;

    [JsonPropertyName("discriminator")]
    public int Discriminator { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; } = default!;

    [JsonPropertyName("game")]
    public Game? Game { get; set; }

}

public class Game
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}
