namespace IdentityAPI
{
    internal class AppConfig
    {
        public static IConfiguration Configuration { get; private set; }

        static AppConfig()
        {
            if (Configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
            }
        }

             public static string? GetConnectionString()
        {
            return Configuration.GetConnectionString("postgres");
        }

    }
}
