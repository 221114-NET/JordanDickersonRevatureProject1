using apilayer;
using BusinessLayer;
using RepoLayer;
using ModelsLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

        // JWT Auth Steps
        // Step 1 install three packages
        // Step 2 Add JWT in appsettings.json
        // Step 3 Add builder.Services.AddAuthentication... in this file under AddSwaggerGen()
        // Step 4 Add builder.Services.AddAuthorization under AddAuthentication
        // Step 5 After the app ref vairable is defined add app.UseAuthorization() and app.UseAuthentication() under app.UseSwagger() 

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

        builder.Services.AddAuthorization();

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
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}
