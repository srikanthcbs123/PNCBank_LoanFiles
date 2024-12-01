using PNCBank_LoanFiles.BusinessEntities;
using PNCBank_LoanFiles.BusinessEntities.Interfaces;
using PNCBank_LoanFiles.RepositoryLayer;
using PNCBank_LoanFiles.RepositoryLayer.Repository;
using PNCBank_LoanFiles.ServiceLayer;
using PNCBank_LoanFiles.ServiceLayer.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilesUploadService, FilesUploadService>();
builder.Services.AddScoped<IFilesUploadRepository, FilesUploadRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.Run();
