using System.Runtime.InteropServices;

namespace EFCore_Sample.Infrastracture
{
    public static class ExternMethods
    {
        [DllImport("System.Net.Security.Native", EntryPoint = "NetSecurityNative_EnsureGssInitialized")]
        public static extern int EnsureGssInitialized();
    }
}
