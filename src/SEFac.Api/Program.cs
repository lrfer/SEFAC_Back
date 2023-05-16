using SEFac.Api.Config;
using SEFAC.Application;
using SEFAC.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCorsConfiguration(builder.Configuration);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureSwagger();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHealthChecks("/health");


app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();



