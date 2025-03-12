using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Data;

namespace OpremiSe.Models
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure the Administrator role exists
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            // Ensure a specific user exists
            var adminEmail = "admin@opremise.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                // Create an admin user
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true // Skip confirmation for simplicity
                };

                await userManager.CreateAsync(adminUser, "AdminPassword123!"); // Set a strong password
            }

            // Assign the user to the Administrator role
            if (!await userManager.IsInRoleAsync(adminUser, "Administrator"))
            {
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Produkti == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }


                if (context.Produkti.Any())
                {
                    return;
                }

                context.Produkti.AddRange(
                    new Produkti
                    {
                        Naziv = "Kolesarske hlače Le Col",
                        Opis = " ",
                        Kategorija = "Oblačila",
                        Kolicina = 22,
                        Cena = 44.99M
                    },

                    new Produkti
                    {
                        Naziv = "Kolesarska majica Le Col",
                        Opis = "Udobna majica, kvaliteten material, ki omogoča manj potenja.",
                        Kategorija = "Oblačila",
                        Kolicina = 22,
                        Cena = 59.99M
                    },

                     new Produkti
                     {
                         Naziv = "Kolo Trek Domane SL 6",
                         Opis = "Visoko zmogljivo vzdržljivostno cestno kolo z ogljikovim okvirjem in integriranimi kolutnimi zavorami.",
                         Kategorija = "Kolo",
                         Kolicina = 5,
                         Cena = 4000.00M
                     },

                      new Produkti
                      {
                          Naziv = "Sedež Selle Italia SLR Boost Superflow",
                          Opis = "Visoko zmogljiv sedež, zasnovan za udobje in optimalno porazdelitev teže med dolgimi vožnjami.",
                          Kategorija = "Kolo - deli",
                          Kolicina = 10,
                          Cena = 299.99M
                      },

                       new Produkti
                       {
                           Naziv = "Kolesarske hlače Pearl Izumi Attack Shorts",
                           Opis = "Udobne kolesarske hlače z materialom, ki odvaja vlago, in brezšivno oblazinjenostjo za podporo.",
                           Kategorija = "Oblačila",
                           Kolicina = 20,
                           Cena = 90.00M
                       },

                        new Produkti
                        {
                            Naziv = "Kolesarske nogavice Swiftwick Aspire Four",
                            Opis = "Zračne in vlago-odvajajoče kolesarske nogavice z rahlo kompresijo za boljše zmogljivosti in udobje.",
                            Kategorija = "Oblačila",
                            Kolicina = 28,
                            Cena = 19.99M
                        }



                );
                context.SaveChanges();
            }
        }
    }
}
