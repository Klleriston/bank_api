using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
    
        services.AddDbContext<DatabaseBank>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        services.AddControllers();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<TransactionServices>();
services.AddScoped<ITransactionRepository, TransactionRepository>();
services.AddScoped<UserServices>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
