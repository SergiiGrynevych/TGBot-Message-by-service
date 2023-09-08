namespace EFCore_Sample.Models
{
    public static class ConfigurationApp
    {
        public static List<string> BotId = new List<string>();
        public static string? Environment { get; set; }
        public static string? CBConnStr { get; set; }
        public static string? CBConnStr_heavy { get; set; }
        public static string? TGToken { get; set; }
        public static string superId { get; set; }
    }
}
