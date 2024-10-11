using AutoMapper;
using back_end_dotnet;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DbBlogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDatabase")));

builder.Services
    .AddConfig(builder.Configuration)
    .AddMyDependencyGroup();
var configurationMapper = new MapperConfiguration(cfg => {
    cfg.AddProfile<OrganizationProfile>();
});
IMapper mapper = configurationMapper.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DbBlogContext>();
    db.Database.Migrate();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

