using Microsoft.EntityFrameworkCore;
using SpeedUpAPI_Redis.Models;

namespace SpeedUpAPI_Redis.ExtensionMethods
{
    public static class MigrationExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {

            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ABContext context= scope.ServiceProvider.GetRequiredService<ABContext>();

            context.Database.Migrate();
        }

    }
}
