using Data;
using FintechBackupScheduler.Helper;
using Hangfire;
using Infrastructure;
using Infrastructure.Implementation;

var builder = WebApplication.CreateBuilder(args);
string dbConnectionString = builder.Configuration.GetConnectionString("SqlConnection");
string dbConnectionString_bk = builder.Configuration.GetConnectionString("SqlConnection_bk");
IConnectionHelper ch = new ConnectionHelper
{
    ConnectionString = dbConnectionString,
    ConnectionString_bk = dbConnectionString_bk
};
builder.Services.AddSingleton<IConnectionHelper>(ch);
builder.Services.AddSingleton<ITaskService, TaskService>();
builder.Services.AddSingleton<IDapperRepository, DapperRepository>();
builder.Services.AddScoped<ICustomeLogger, CustomeLogger>();
builder.Services.AddTransient(typeof(ICustomeLogger<>), typeof(CustomeLogger<>));
// Add services to the container.
builder.Services.AddHangfire(x => x.UseSqlServerStorage(dbConnectionString_bk));
builder.Services.AddHangfireServer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/dashboard", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() },
    AppPath = "/swagger"
});
app.Run();
