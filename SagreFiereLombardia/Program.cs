using Sagre_FiereLombardia.WSSoap;
using SoapCore;

namespace Sagre_FiereLombardia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Aggiunta dipendenza SOAP con servizio SoapCore
            builder.Services.AddSoapCore();
            builder.Services.AddScoped<ILombardiaEventsService, LombardiaEventsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Event/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // TODO Capire come modificare per far funzionare EventController.cs
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Event}/{action=Index}/{id?}");

            // Aggiunta endpoint wsdl
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<ILombardiaEventsService>("/LombardiaEventsService.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });


            app.Run();
        }
    }
}