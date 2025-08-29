using System.ComponentModel.DataAnnotations;

namespace WebApi.Helpers
{
    public class Validation
    {
        public static class URLValidator
        {
            public static ValidationResult ValidateUrl(string url, ValidationContext context)
            {
                if (string.IsNullOrEmpty(url))
                    return new ValidationResult("URL is required");

                if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                {
                    return new ValidationResult("Only valid HTTP/HTTPS URLs are allowed");
                }

                return ValidationResult.Success;
            }
        }
    }
}
