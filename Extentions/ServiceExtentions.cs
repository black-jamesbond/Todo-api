using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Todo.DbContexts;

namespace Todo.Extentions
{
    public static class ServiceExtentions
    {
       public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoItemContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
