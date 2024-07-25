using BusinessLogic.Books;
using BusinessLogic.Mappers;
using DataAccess.DBStorage;
using WebApp;
using WebApp.Mappers;

namespace WebApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddExceptionHandler<ExceptionHandler>(); // adding the exception hanndler

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            // add mappers 
            builder.Services.AddSingleton<WebApp.Mappers.IBookMapper, WebApp.Mappers.BookMapper>();
            builder.Services.AddSingleton<BusinessLogic.Mappers.IBookMapper, BusinessLogic.Mappers.BookMapper>();
            builder.Services.AddSingleton<BusinessLogic.Mappers.IReviewMapper, BusinessLogic.Mappers.ReviewMapper>();

            // add SQL objects 
            builder.Services.AddSingleton<ISQLReviewsStorageService, SQLReviewsStorageService>(s => new SQLReviewsStorageService(connString)); 
            builder.Services.AddSingleton<ISQLBooksStorageService, SQLBooksStorageService>(s => new SQLBooksStorageService(connString));

            // add service layer book business logic 
            builder.Services.AddSingleton<IBookService, BookService>();

            builder.Services.AddControllers(); // the app will know to look for controllers 

            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            app.UseExceptionHandler(options => { }); // using the exception handler 
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
