using Microsoft.EntityFrameworkCore;
using FlashcardWebApp.Services;
using FlashcardWebApp.Interface;
using FlashcardWebApp.Repository;
using FlashcardWebApp.Middleware;
using FlashcardWebApp.Interceptors;
namespace FlashcardWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.ConfigureServices((hostContext, services) =>
             {
                 services.AddDistributedMemoryCache(); 
                 services.AddSession(options =>
                 {
                     options.IdleTimeout = TimeSpan.FromMinutes(30);
                     options.Cookie.HttpOnly = true;
                     options.Cookie.IsEssential = true;
                 });
                 services.AddDbContext<ApplicationDbContext>(options =>
                 {
                     options.UseSqlite(hostContext.Configuration.GetConnectionString("DefaultConnection"));
                     options.AddInterceptors(new StudySetCapitalizationInterceptor());
                 });
                 services.AddControllersWithViews();
                 services.AddScoped<IFlashcardRepository, FlashcardRepository>();
                 services.AddScoped<IStudySetRepository, StudySetRepository>();
                 services.AddScoped<IFlashcardService, FlashcardService>();
                 services.AddScoped<IStudySetService, StudySetService>();
                 services.AddScoped<IExcelService, ExcelService>();
                 services.AddScoped<IApiService, ApiService>();
             })
             .Configure(app =>
             {
                 var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                
                 if (env.IsDevelopment())
                 {
                     app.UseDeveloperExceptionPage();
                 }
                 else
                 {
                     app.UseExceptionHandler("/Home/Error");
                     app.UseHsts();
                 }

                 app.UseHttpsRedirection();
                 app.UseStaticFiles();
                 app.UseRouting();
                 app.UseAuthorization();
                 app.UseMiddleware<DatabaseMiddleware>();
                 app.UseDatabaseMiddleware();
                 app.UseSession();
                 app.UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");
                 });
             });
         });

    }
}
