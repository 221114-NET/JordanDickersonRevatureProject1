using apilayer;
using BusinessLayer;
using RepoLayer;
using ModelsLayer;

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
        builder.Services.AddScoped<IBusinessClassSignUpRequest, BusinessClassSignUpRequest>();
        builder.Services.AddScoped<IBusinessClassLogInRequest, BusinessClassLogInRequest>();
        builder.Services.AddScoped<IBusinessClassReimbursementRequest, BusinessClassReimbursementRequest>();
        builder.Services.AddScoped<IBussinessUpdatePendingRequest, BussinessUpdatePendingRequest>();
        builder.Services.AddScoped<IBusinessClassViewPendingRequest, BusinessClassViewPendingRequest>();
        builder.Services.AddScoped<IBussinessClassViewAllMyTickets, BussinessClassViewAllMyTickets>();
        builder.Services.AddScoped<IBusinessClassFilterMyTickets, BusinessClassFilterMyTickets>();
        builder.Services.AddScoped<IBusinessClassEditNameRequest, BusinessClassEditNameRequest>();
        
        builder.Services.AddScoped<IRepoClassSignUpRequest, RepoClassSignUpRequest>();
        builder.Services.AddScoped<IRepoClassLogInRequest, RepoClassLogInRequest>();
        builder.Services.AddScoped<IRepoClassReimbursementRequest, RepoClassReimbursementRequest>();
        builder.Services.AddScoped<IRepoUpdatePendingRequest, RepoUpdatePendingRequest>();
        builder.Services.AddScoped<IRepoClassViewPendingRequest, RepoClassViewPendingRequest>();
        builder.Services.AddScoped<IRepoClassViewAllMyTickets, RepoClassViewAllMyTickets>();
        builder.Services.AddScoped<IRepoClassFilterMyTickets, RepoClassFilterMyTickets>();
        builder.Services.AddScoped<IRepoClassEditNameRequest, RepoClassEditNameRequest>();

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
