using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadNet.API.Profiles;
using ReadNet.DataAccess.Context;
using ReadNet.DataAccess.Repositories;
using ReadNet.DataAccess.Seeders;
using ReadNet.Domain.Interfaces;
using ReadNet.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Repositorios
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ILoanDetailRepository, LoanDetailRepository>();


// Servicios
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ILoanDetailService, LoanDetailService>();

var app = builder.Build();


// Ejecutar Seeder automáticamente
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

    context.Database.Migrate();

    DataSeeder.Seed(context);
}


// Configurar la canalización HTTP

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();