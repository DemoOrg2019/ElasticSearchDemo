using Elasticsearch.Net;
using Microsoft.EntityFrameworkCore;
using Nest;
using Nest.JsonNetSerializer;
using NOV.ES.MDMSearch.API.Infrastructure;
using NOV.ES.MDMSearch.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CrossOrigin",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
        );
});

// Dependency Registration
builder.Services.AddDbContext<MdmDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["MDMDBConnString"],
        sqlServerOptionsAction: sqlOptions =>
        {            
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
    },
    ServiceLifetime.Scoped
);

builder.Services.AddTransient<IMDMSearchIndexService, MDMSearchIndexService>();

var uri = new Uri(builder.Configuration["elasticsearch:url"]);
var pool = new SingleNodeConnectionPool(uri);
var settings = new ConnectionSettings(pool, JsonNetSerializer.Default)
    .DisableDirectStreaming(); // <TODO> Remove this settings.

ElasticClient client = new ElasticClient(settings);
builder.Services.AddSingleton<IElasticClient>(client);


var app = builder.Build();

app.UseCors("CrossOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
