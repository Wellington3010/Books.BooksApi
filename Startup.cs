using AutoMapper;
using Books.BooksApi.Data;
using Books.BooksApi.Interfaces;
using Books.BooksApi.Models;
using Books.BooksApi.Services;
using Books.BooksApi.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = false;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Books.BooksApi", Version = "v1" });
            });

            var config = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<AuthorViewModel, Author>();
                mapper.CreateMap<BookViewModel, Book>();
                mapper.CreateMap<CategoryViewModel, Category>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddScoped<ApiContext, ApiContext>();
            services.AddSingleton(mapper);
            services.AddDbContext<ApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBooksManagerService, BooksManagerService>();
            services.AddScoped<IAuthorService<Author>, AuthorManagerService>();
            services.AddScoped<ICategoryService<Category>, CategoryManagerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books.BooksApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
