using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.DataSeeder;
using WebApi.Data.Repositories;

namespace WebApi.Data.DataMigration
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<QuestionDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                        new QuestionSeeder(scope.ServiceProvider.GetRequiredService<IQuestionRepository>()).SeedData();
                        new ChoiceSeeder(scope.ServiceProvider.GetRequiredService<IChoiceRepository>(),
                            scope.ServiceProvider.GetRequiredService<IQuestionRepository>()).SeedData();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return host;
        }
    }
}