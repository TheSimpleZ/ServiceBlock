using System.Collections.Generic;

namespace ServiceBlock.Options
{
    public class Security
    {
        public string? Domain { get; set; }
        public string? ApiIdentifier { get; set; }
        public string? ClientId { get; set; }

        public Dictionary<string, string>? Scopes { get; set; }
    }
}