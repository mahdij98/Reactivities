using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace persist
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Meetinges.Any()) return;
            var meetinges = new List<Meeting>
             {
                new Meeting {
                    Title = "Bax Mahal",
                    Date = DateTime.Now.AddMonths(-3),
                    Subject = "rap battel",
                    Address = "Mashhad - Pole Rasekhon",
                    Description = "with no geear",
                },
                new Meeting {
                    Title = "Porfosoran",
                    Date = DateTime.Now.AddMonths(4),
                    Subject = "street fights",
                    Address = "Isfehan - 33Pole",
                    Description = "with no geear",
                },
                new Meeting {
                    Title = "pink girls",
                    Date = DateTime.Now.AddMonths(1),
                    Subject = "rap battle",
                    Address = "Tehran - baghe ketab",
                    Description = "with",
                },
            };

            await context.Meetinges.AddRangeAsync(meetinges);
            await context.SaveChangesAsync();
        }
    }
}