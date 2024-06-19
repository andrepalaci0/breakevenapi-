using Microsoft.EntityFrameworkCore;
namespace breakevenApi.Infraestructre
{
    public static class DatabaseManagementService
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }
        }
    }
}
