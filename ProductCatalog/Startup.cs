using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;
using ProductCatalog.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //AddTransient Executa toda vez que for solicitado
            //AddScoped Verifica se já existe e retorna, caso não exista cria(Singleton)

            services.AddMvc();
            services.AddResponseCompression();
            
            services.AddScoped<StoreDataContext, StoreDataContext>(); 
            services.AddTransient<ProductRepository,ProductRepository>();
            services.AddTransient<CategoryRepository,CategoryRepository>();

            // services.AddSwaggerGen(x=>{
            //     x.SwaggerDoc("v1", new Info{Title="API Product Catalog", Version="v1"});
            // });
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseResponseCompression();
            // app.UseSwaggerUI(c =>{
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json","API Product Catalog - v1");
            // });
             
        }
    }
}
