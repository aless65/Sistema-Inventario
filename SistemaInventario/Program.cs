using AcademiaFS.Proyecto.Inventario._Features.Auth;
using AcademiaFS.Proyecto.Inventario._Features.Estados;
using AcademiaFS.Proyecto.Inventario.Domain;
using AcademiaFS.Proyecto.Inventario.Utility;
using Microsoft.EntityFrameworkCore;
using SistemaInventario._Common;
using SistemaInventario._Features.Empleados;
using SistemaInventario._Features.Lotes;
using SistemaInventario.Infrastructure;
using SistemaInventario.Infrastructure.Inventario_AJM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerForFsIdentityServer(opt =>
//{
//    opt.Title = "Inventario";
//    opt.Description = "Wow";
//    opt.Version = "v1";
//});

var connectionString = builder.Configuration.GetConnectionString("SistemaInventario");
builder.Services.AddDbContext<InventarioAjmContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddTransient<UnitOfWorkBuilder, UnitOfWorkBuilder>();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<EmpleadoService>();
builder.Services.AddTransient<EstadoService>();
builder.Services.AddTransient<LoteService>();
builder.Services.AddTransient<ProductoService>();
builder.Services.AddTransient<SalidasInventarioService>();
builder.Services.AddTransient<SucursalService>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<DomainService>();

builder.Services.AddTransient<CommonService>();

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
