using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Seeders
{
    public class AppDbSeeder
    {
        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                if (await appDbContext.Database.EnsureCreatedAsync())
                {
                    if (!await appDbContext.Values.AnyAsync())
                    {
                        await InsertSampleData(appDbContext);
                    }
                }
            }
        }

        private async Task InsertSampleData(AppDbContext appDbContext)
        {
            var values = GetValues();
            await appDbContext.Values.AddRangeAsync(values);
            try
            {
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private List<Value> GetValues()
        {
            var values = new List<Value>()
            {
                new Value()
                {
                    Val = "Val1"
                },
                new Value()
                {
                    Val = "Val2"
                },
                new Value()
                {
                    Val = "Val3"
                },
                new Value()
                {
                    Val = "Val4"
                }
            };

            return values;
        }
    }
}
