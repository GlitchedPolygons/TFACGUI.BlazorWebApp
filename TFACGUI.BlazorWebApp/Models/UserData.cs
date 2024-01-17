using System.Text.Json.Serialization;
using GlitchedPolygons.ExtensionMethods;

namespace TFACGUI.BlazorWebApp.Models;

/// <summary>
/// TFACGUI user data instance.
/// </summary>
public class UserData
{
    /// <summary>
    /// Empty (default) <see cref="UserData"/> instance.
    /// </summary>
    public static readonly UserData Empty = new();
    
    /// <summary>
    /// Checks whether the <see cref="UserData"/> is empty ("fresh") or not.
    /// </summary>
    [JsonIgnore]
    public bool IsEmpty => Chain.NullOrEmpty();
    
    /// <summary>
    /// The user's chain of 2FA secrets and all of their surrounding metadata and settings.
    /// </summary>
    public IList<TotpConfig> Chain { get; set; } = new List<TotpConfig>();
}