using System.Reflection;

namespace ServiceBlock.Extensions
{
    public class Block
    {
        public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;

    }
}