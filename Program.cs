using System.Net;

namespace WebAPIArenaCactus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var enderecoIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://{enderecoIp}:9090");
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}