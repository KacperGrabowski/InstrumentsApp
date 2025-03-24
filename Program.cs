using InstrumentsApp.Context;
using InstrumentsApp.Forms;
using InstrumentsApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstrumentsApp
{
    public static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ServiceProvider = new ServiceCollection()
            .AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .AddScoped<UserService>()
            .BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}