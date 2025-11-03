using myproject.Debugging;

namespace myproject
{
    public class myprojectConsts
    {
        public const string LocalizationSourceName = "myproject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "938fe931bd2f4668bdf41a6f6a2f07ee";
    }
}
