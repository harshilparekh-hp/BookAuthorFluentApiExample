using AutoMapper;
using BlogPostFluentApiExample.DAL;
using BlogPostFluentApiExample.DTOs;
using BlogPostFluentApiExample.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BlogPostFluentApiExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Fluent Validations Configurations
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddFluentValidationClientsideAdapters();

            // DI for Fluent Validations
            builder.Services.AddSingleton<IValidator<Author>, AuthorValidator>();
            // Dependency Injections
            builder.Services.AddScoped<IContext, Context>();

            builder.Services.AddScoped<IAuthorDAL, AuthorDAL>();
            // builder.Services.AddScoped<IBookDAL, BookDAL>();

            // DI for generic repository
            builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
            builder.Services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();

            // Mapper Configurations
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

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
        }
    }
}
