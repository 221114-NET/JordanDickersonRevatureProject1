using apilayer;
using BusinessLayer;
using RepoLayer;

namespace apilayer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //register di ------------------------------------------------------------
        // we have to register denpendency injection because we need to tell the builder which class implements the said interface
        builder.Services.AddScoped<IBusinessClass, BusinessClass>(); 
        builder.Services.AddScoped<IRepoClass, RepoClass>();
        builder.Services.AddSingleton<IMyLogger, MyLogger>();
        // ------------------------------------------------------------------------

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
