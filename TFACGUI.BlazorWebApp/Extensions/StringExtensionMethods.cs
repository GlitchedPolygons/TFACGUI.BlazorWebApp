using GlitchedPolygons.ExtensionMethods;
using OtpNet;

namespace TFACGUI.BlazorWebApp.Extensions;

public static class StringExtensionMethods
{
    public static OtpHashMode ToOtpHashMode(this string algorithm)
    {
        switch (algorithm.ToLowerInvariant())
        {
            default:
            {
                return OtpHashMode.Sha1;
            }
            case "256":
            case "sha256":
            case "sha-256":
            {
                return OtpHashMode.Sha256;
            }
            case "512":
            case "sha512":
            case "sha-512":
            {
                return OtpHashMode.Sha512;
            }
        }
    }

    public static bool IsValidBase32(this string base32)
    {
        try
        {
            byte[] totpSecretBase32Decoded = Base32Encoding.ToBytes(base32);

            return totpSecretBase32Decoded.NotNullNotEmpty();
        }
        catch
        {
            return false;
        }
    }
}