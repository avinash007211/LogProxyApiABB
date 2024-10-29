
using LogProxyApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

//builder.Services.AddDbContext<LogProxyDbContext>(option => option.UseSqlServer
//(@"Data Source=SHIVARAM\SQLEXPRESS;Initial Catalog=LogDb;"));

builder.Services.AddDbContext<LogProxyDbContext>(options =>
options.UseSqlServer(@"Data Source=CE63466\SQLEXPRESS;Initial Catalog=LogDb;Integrated Security=True;"));

builder.Services.AddAuthentication(options =>

{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>

{

    options.Authority = "https://dev-4pi5vpvpve11drn7.us.auth0.com/";
    options.Audience = "https://localhost:7113/";

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var dbContext = scope.ServiceProvider.GetRequiredService<LogProxyDbContext>();

    dbContext.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(

  name: "default",

  pattern: "{controller=Home}/{action=Index}/{id?}");




app.MapControllers();

app.Run();
