using System.Collections.Generic;

namespace ServiceBlock.Options
{
    class Security
    {
        public string? Domain { get; set; }
        public string? ApiIdentifier { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }

        public IEnumerable<string> Scopes { get; set; } = new[] { "openid", "email", "profile" };
    }
}