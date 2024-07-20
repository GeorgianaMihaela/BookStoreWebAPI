using WebApp;

namespace WebAPIsNoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddExceptionHandler<ExceptionHandler>(); // adding the exception hanndler

            builder.Services.AddControllers(); // the app will know to look for controllers 

            builder.Services.AddSwaggerGen();

            builder.Configuration.GetConnectionString("DefaultConnection");


            var app = builder.Build();
            app.UseExceptionHandler(opt => { }); // using the exception handler 
            app.MapControllers(); // maps the routes with the methods

            // adding swagger 
            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.Run();
        }
    }
}
