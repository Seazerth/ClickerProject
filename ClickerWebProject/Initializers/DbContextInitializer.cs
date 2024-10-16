using System.Reflection;
using ClickerWebProject.Domain;
using ClickerWebProject.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ClickerWebProject.Initilizers
{
    public static class DbContextInitializer
    {
        public static void AddAppDbContext(IServiceCollection services)
        {
            var pathToDbFile = GetPathToDbFile();
            services
                .AddDbContext<AppDbContext>(options => options
                    .UseSqlite($"Data Source={pathToDbFile}"));

            string GetPathToDbFile()
            {
                var applicationFolder = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "CSharpClicker");

                if (!Directory.Exists(applicationFolder))
                {
                    Directory.CreateDirectory(applicationFolder);
                }

                return Path.Combine(applicationFolder, "CSharpClicker.db");
            }
        }

        public static void InitializeDbContext(AppDbContext appDbContext)
        {

            const string Boost1 = "Танго";
            const string Boost2 = "Врайзбенд";
            const string Boost3 = "Шедоублейд";
            const string Boost4 = "Рапира";
            const string Boost5 = "Аегис";

            appDbContext.Database.Migrate();
            
            var existingBoost = appDbContext.Boosts
            .ToArray();

            AddBoostIfNotExist(Boost1, price: 100,profit: 1);
            AddBoostIfNotExist(Boost2, price: 500, profit: 15);
            AddBoostIfNotExist(Boost3, price: 2000, profit: 60, isAuto: true);
            AddBoostIfNotExist(Boost4, price: 7000, profit: 400);
            AddBoostIfNotExist(Boost5, price: 50000, profit: 2500, isAuto: true);

            appDbContext.SaveChanges();

            void AddBoostIfNotExist(string name, long price, long profit, bool isAuto = false)
            {
                if (!existingBoost.Any(eb => eb.Title == name))
                {
                    var pathToImage = Path.Combine(".", "Resourses", "BoostImagers", $"{name}.png");
                    using var fileStream = File.OpenRead(pathToImage);
                    using var memoryStream = new MemoryStream();

                    fileStream.CopyTo(memoryStream);

                    appDbContext.Boosts.Add(new Boost
                    {
                        Title = name,
                        Price = price,
                        Profit = profit,
                        IsAuto = isAuto,
                        Image = memoryStream.ToArray(),

                    });
                }
            }

        }
    }

}
