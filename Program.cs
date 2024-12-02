using EmployeeCRUDAPI.BAL;
using EmployeeCRUDAPI.DAL.DBContext;
using EmployeeCRUDAPI.DAL.IRepositories;
using EmployeeCRUDAPI.DAL.Repositories;
using EmployeeCRUDAPI.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DB Connection
builder.Services.AddDbContext<EmployeeContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("EmployeeCRUDAPI")));

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
