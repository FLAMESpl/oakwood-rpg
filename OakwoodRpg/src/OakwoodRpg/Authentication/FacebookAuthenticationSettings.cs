using System.ComponentModel.DataAnnotations;

namespace OakwoodRpg.Authentication;

public record FacebookAuthenticationSettings
{
    [Required]
    public string AppId { get; set; } = null!;

    [Required]
    public string AppSecret { get; set; } = null!;
}
