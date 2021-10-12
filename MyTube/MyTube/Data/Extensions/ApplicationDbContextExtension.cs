namespace MyTube.Data.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using MyTube.Models;

    using static GlobalConstants.GlobalConstants;

    public static class ApplicationDbContextExtension
    {
        private const string AdminId = "3dd43897-b531-464b-a3d4-b50b8c12ce0f";

        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedAdministrator(services);
            SeedContextData(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedContextData(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            if (!context.Videos.Any())
            {
                context.Videos.AddRange(
                    new Video
                    {
                        Title = "MISTY - Ты и я (Премьера клипа, 2020)",
                        VideoUrl = "https://www.youtube.com/watch?v=YbA3E5UnTYc&list=RDEMq7s2fLlD67949m-1QJkFaQ&start_radio=1&ab_channel=MISTY",
                        VideoImageUrl = "https://i.ytimg.com/vi/lOPuiNNUM0g/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBSduHOv8pAgZDQawqtSZX-7WhOSQ",
                        Description = "Слушай новинки первым! Подпишись - https://goo.gl/VW7uZ1 Hit the 🔔 to join the notification squad and to not miss any new uploads!",
                        ViewsCount = 15000,
                        LikesCount = 153,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "The Weeknd & Ariana Grande - Save Your Tears",
                        VideoUrl = "https://www.youtube.com/watch?v=LIIDh-qI9oI&ab_channel=TheWeekndVEVO",
                        VideoImageUrl = "https://www.nme.com/wp-content/uploads/2021/04/the-weeknd-ariana-grande-save-your-tears-remix-video@2000x1270.jpg",
                        Description = "Official music video by The Weeknd & Ariana Grande performing 'Save Your Tears' (Remix), available everywhere now: https://TheWeeknd.lnk.to/SYTRMX",
                        ViewsCount = 25000,
                        LikesCount = 567,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "Misty - La Isla Bonita",
                        VideoUrl = "https://www.youtube.com/watch?v=B5tXmw1Z9XQ&ab_channel=MISTY",
                        VideoImageUrl = "https://i.ytimg.com/vi/B5tXmw1Z9XQ/hqdefault.jpg?sqp=-oaymwEcCNACELwBSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBz3eXP7EKKOoVZN-rGHCZ8FWedhw",
                        Description = "Stream/Download:https://band.link/MDlzE",
                        ViewsCount = 57000,
                        LikesCount = 5775,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "Riton x Nightcrawlers - Friday ",
                        VideoUrl = "https://www.youtube.com/watch?v=U6n2NcJ7rLc",
                        VideoImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/Riton_-_Friday.png",
                        Description = "Riton x Nightcrawlers Ft. Mufasa x Hypeman (Dopamine Re-Edit) 'Friday' is out now. Listen here: https://lnk.to/FridayRNMHyd",
                        ViewsCount = 34623,
                        LikesCount = 4735,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "IVKA BEIBE - NEPOZNATI  ",
                        VideoUrl = "https://www.youtube.com/watch?v=dTrJRAkgAjQ&ab_channel=%D0%9A%D0%B0%D0%BD%D0%B0%D0%BB%D0%AA",
                        VideoImageUrl = "https://i.ytimg.com/vi/dTrJRAkgAjQ/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLDIZfIgn7_TgWaG1xw2qI3BAwtrXw",
                        Description = "Последвай Ivka Beibe:Instagram: https://www.instagram.com/ivkabeibe/TikTok: https://www.tiktok.com/@ivkabeibe",
                        ViewsCount = 4221,
                        LikesCount = 2100,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "Dua Lipa - Love Again ",
                        VideoUrl = "https://www.youtube.com/results?search_query=love+again",
                        VideoImageUrl = "https://i1.sndcdn.com/artworks-EyhFUXfXDUQrQNLk-SWQDsA-t500x500.jpg",
                        Description = "The official music video for Dua Lipa – Love AgainStream Love Again: https://dualipa.co/LoveAgain",
                        ViewsCount = 67000,
                        LikesCount = 6322,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "Zivert - Life | Премьера клипа",
                        VideoUrl = "https://www.youtube.com/watch?v=9LtaOKsbhBk&ab_channel=Zivert",
                        VideoImageUrl = "https://i1.sndcdn.com/artworks-000454220556-ccnp69-t500x500.jpg",
                        Description = "Состояние - автопилот Когда чувства без берегов Тебе кажется это навечно ",
                        ViewsCount = 21000,
                        LikesCount = 1334,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    },
                    new Video
                    {
                        Title = "Vanotek Feat. Eneli - Back To Me",
                        VideoUrl = "https://www.youtube.com/watch?v=GbdVAl03W_M&ab_channel=NatoGogichashvili",
                        VideoImageUrl = "https://i.ytimg.com/vi/GbdVAl03W_M/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLDBiooJXWJDfXPROE81vnmIsE0Nxg",
                        Description = "Vanotek Feat. Eneli - Back To Me (Robert Cristian Remix)",
                        ViewsCount = 6532,
                        LikesCount = 1414,
                        CreatedOn = DateTime.Now,
                        ApplicationUserId = AdminId
                    }
                    );
                context.SaveChanges();
            }
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@app.com";
                    const string adminPassword = "admin12app";

                    var user = new ApplicationUser
                    {
                        Id = AdminId,
                        Email = adminEmail,
                        UserName = adminEmail,
                        AccountPictureUrl = "https://wallpaperaccess.com/full/2213449.jpg"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
