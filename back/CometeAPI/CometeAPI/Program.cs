using CometeAPI.Application;
using CometeAPI.Application.mappers;
using CometeAPI.Application.Service;
using CometeAPI.Domain.repositories;
using CometeAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<OpenAiService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<ReportMapper>();

builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<FolderService>();
builder.Services.AddScoped<FolderMapper>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IFolderTagReporitory, FolderTagRepository>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<TagMapper>();
builder.Services.AddScoped<FolderTagMapper>();

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