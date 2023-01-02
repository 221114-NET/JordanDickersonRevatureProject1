using apilayer;
using BusinessLayer;
using RepoLayer;
using ModelsLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace apilayer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // added cors policies
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("FormPolicy",
            policy =>
            {
                policy.WithOrigins("http://localhost:3000/")
                                .WithMethods("POST");
            });
        });

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddRazorPages();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        // JWT Auth Steps
        // Step 1 install three packages
        // Step 2 Add JWT in appsettings.json
        // Step 3 Add builder.Services.AddAuthentication... in this file under AddSwaggerGen()
        // Step 4 Add builder.Services.AddAuthorization under AddAuthentication
        // Step 5 After the app ref vairable is defined add app.UseAuthorization() and app.UseAuthentication() under app.UseSwagger() 
        // Step 6 Set up claims for businessclassloginrequest
        // Step 7 Set up [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] for http request that need it
        // Step 8 add options => to builder.services.AddSwaggerGen()

        builder.Services.AddSwaggerGen(options => 
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Bearer Authentication with JWT Token",
                Type = SecuritySchemeType.Http
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        });


        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:5255/",
                ValidAudience = "http://localhost:5255/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("custom key authentication"))
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

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}
