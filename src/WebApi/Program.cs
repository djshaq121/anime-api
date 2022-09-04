using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi;
using WebApi.HealthCheck;
using WebApi.Model;
using WebApi.Repository;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.Configure<SearchSettings>(configuration.GetSection("SearchSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddDbContextCheck<AnimeDbContext>();

builder.Services.AddDbContext<AnimeDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<AnimeRepository>();
builder.Services.AddScoped<ISearchService, SearchService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";

        var response = new HealthCheckResponse
        {
            Status = report.Status.ToString(),
            HealthChecks = report.Entries.Select(x => new HealthCheck
            {
                Component = x.Key,
                Status = x.Value.Status.ToString(),
                Description = x.Value.Description
            }),

            Duraction = report.TotalDuration
        };

        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
});
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();