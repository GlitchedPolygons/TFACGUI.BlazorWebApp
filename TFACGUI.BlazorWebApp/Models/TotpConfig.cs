﻿using System.Text;
using System.Text.Json.Serialization;
using GlitchedPolygons.ExtensionMethods;
using OtpNet;

namespace TFACGUI.BlazorWebApp.Models;

/// <summary>
/// TFACGUI entry.
/// <para> </para>
/// https://github.com/google/google-authenticator/wiki/Key-Uri-Format
/// </summary>
public class TotpConfig
{
    /// <summary>
    /// Default (empty) <see cref="TotpConfig"/> instance (useful for checking the default values assigned to the various TOTP parameters).
    /// </summary>
    public static readonly TotpConfig Empty = new();

    /// <summary>
    /// Element-ID for this <see cref="TotpConfig"/> entry.
    /// </summary>
    [JsonIgnore]
    public string Id => $"{Name}{Label}{Digits}{Period}{(int)Algorithm}{TotpSecretKey.SHA256()}".SHA256(true);

    /// <summary>
    /// The name that the user gives this <see cref="TotpConfig"/> entry.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// The label that was encoded into the <c>otpauth://totp/</c> URI (typically, this also describes the <see cref="TotpConfig"/>, just like the user-definable <see cref="Name"/>).<para> </para>
    /// The label is used to identify which account a key is associated with.<para> </para>
    /// It contains the issuer and user id separated by a color, as specified by the Google Authenticator Key URI format specification (https://github.com/google/google-authenticator/wiki/Key-Uri-Format).
    /// </summary>
    public string Label => Issuer.NotNullNotEmpty() && IssuedTo.NotNullNotEmpty() ? $"{Issuer}:{IssuedTo}" : string.Empty;

    /// <summary>
    /// The issuer parameter is a string value indicating the provider or service this account is associated with, URL-encoded according to RFC 3986.
    /// </summary>
    public string Issuer { get; init; } = string.Empty;

    /// <summary>
    /// The "user id" used to identify which account this key is associated with.
    /// </summary>
    public string IssuedTo { get; init; } = string.Empty;

    /// <summary>
    /// How many digits the 2FA tokens generated by this <see cref="TotpConfig"/> have. By default this is <c>6</c>.
    /// </summary>
    public int Digits { get; init; } = 6;

    /// <summary>
    /// The period parameter defines a period that a TOTP code will be valid for, in seconds. The default value is <c>30</c>.
    /// </summary>
    public int Period { get; init; } = 30;

    /// <summary>
    /// TOTP hashing algo (default is SHA-1).
    /// </summary>
    public OtpHashMode Algorithm { get; init; } = OtpHashMode.Sha1;

    /// <summary>
    /// Base32-encoded 2FA secret.
    /// </summary>
    public string TotpSecretKey { get; init; } = string.Empty;

    /// <summary>
    /// Brightness value that animated between the values 150% and 100% on-totp-copy (the fast flashy thingy).
    /// </summary>
    [JsonIgnore]
    public float CardBrightnessAnimationValue { get; set; } = 1.0f;

    /// <summary>
    /// Minimum width of the card containing this <see cref="TotpConfig"/>'s output.
    /// </summary>
    [JsonIgnore]
    public string CardMinWidth
    {
        get
        {
            return TotpRaw.Length switch
            {
                9 => "22.5rem !important",
                10 => "25rem !important",
                _ => "20rem !important"
            };
        }
    }

    private Totp? totpInstance;

    private readonly StringBuilder totpStringBuilder = new(16);

    private void EnsureTotpInstanceExists()
    {
        if (totpInstance is not null)
        {
            return;
        }

        totpInstance = new Totp
        (
            Base32Encoding.ToBytes(TotpSecretKey),
            Period,
            Algorithm,
            Digits
        );
    }

    /// <summary>
    /// The remaining seconds for the current TOTP generated by this <see cref="TotpConfig"/>.
    /// </summary>
    [JsonIgnore]
    public double RemainingSeconds
    {
        get
        {
            EnsureTotpInstanceExists();

            return Period - (((DateTime.UtcNow.Ticks - DateTime.UnixEpoch.Ticks) / 10_000_000.0d) % Period);
        }
    }

    /// <summary>
    /// Remaining time for the current TOTP generated by this <see cref="TotpConfig"/> measured in percentage. Kinda like health bars in video games.
    /// </summary>
    [JsonIgnore]
    public double RemainingLifetimePercentage => (RemainingSeconds / Period) * 100.0d;

    /// <summary>
    /// The current TOTP computed by this <see cref="TotpConfig"/>'s 2FA secret and algo parameters, without any spaces or other symbols. Just digits.
    /// </summary>
    [JsonIgnore]
    public string TotpRaw
    {
        get
        {
            EnsureTotpInstanceExists();

            return totpInstance!.ComputeTotp();
        }
    }
    
    /// <summary>
    /// Whether the TOTP is in the copied state.
    /// </summary>
    [JsonIgnore]
    public bool Copied { get; set; }

    /// <summary>
    /// The current TOTP computed by this <see cref="TotpConfig"/>'s 2FA secret and algo parameters, nicely formatted and all.
    /// </summary>
    [JsonIgnore]
    public string Totp
    {
        get
        {
            EnsureTotpInstanceExists();

            if (Copied)
            {
                return "\u2705Copied...";
            }

            try
            {
                string totp = totpInstance!.ComputeTotp();

                switch (Digits)
                {
                    case <= 5:
                    {
                        return totp;
                    }
                    case 6:
                    {
                        return totp
                            .Insert(3, " ");
                    }
                    case 8:
                    {
                        return totp
                            .Insert(4, " ");
                    }
                    case 9:
                    {
                        return totp
                            .Insert(3, " ")
                            .Insert(7, " ");
                    }
                    default:
                    {
                        totpStringBuilder.Clear();

                        for (int i = 0; i < totp.Length; ++i)
                        {
                            totpStringBuilder.Append(totp[i]);

                            if ((i + 1) % 2 == 0)
                            {
                                totpStringBuilder.Append(' ');
                            }
                        }

                        return totpStringBuilder.ToString();
                    }
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine($"TOTP generation for chain entry \"{Label}\" (user label: \"{Name}\") failed. Thrown exception: {e.ToString()}");
#endif
                return "ERROR";
            }
        }
    }
}