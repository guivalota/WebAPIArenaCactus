namespace WebAPIArenaCactus.Models
{
    public class Connection
    {
        public string GetConnMySQL()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            return configuration.GetConnectionString("MySqlDbConnection");
        }
    }
}
