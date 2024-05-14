namespace WebAPIArenaCactus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public String ConnString = "";

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            configuration.GetConnectionString("MySqlDbConnection");

            services.AddSingleton<IConfiguration>(Configuration);
        }
    }
}
