using System.Reflection;
using System.Text;

namespace Yeremenko_HW2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IManagementCars, ManagementCars>();

            Car.GenerateRandomCarsList(10);

            var app = builder.Build();
            var car = app.Services.GetService<IManagementCars>();

            app.Map("", start =>
            {
                
                start.Map("/all", all =>
                {
                    all.MapWhen(context =>
                    {
                        return context.Request.QueryString.Equals(null);
                    }, GetAllCars);
                });
                start.Map("/models", mod =>
                {
                    mod.MapWhen(context =>
                    {
                       return (context.Request.QueryString.Equals(null) || context.Request.Query.ContainsKey("id"));
                    }, GetCarsModels);
                });
                start.Map("/ages", ages =>
                {
                    ages.MapWhen(context =>
                    {
                        return (context.Request.QueryString.Equals(null) || context.Request.Query.ContainsKey("id"));
                    }, GetCarsAges);
                });
                start.Map("/engines", engines =>
                {
                    engines.MapWhen(context =>
                    {
                        return (context.Request.QueryString.Equals(null) || context.Request.Query.ContainsKey("id"));
                    }, GetCarsEngines);
                });
                start.MapWhen(context =>
                {
                    return context.Request.QueryString.Equals(null);
                }, GetMenu);
            }
            );

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
        
        private static void GetAllCars(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(Car.GetCarsListInfo());

            });
        }
        private static void GetCarsModels(IApplicationBuilder app)
        {
            var car = app.ApplicationServices.GetService<IManagementCars>();
            app.Run(async context =>
            {
                if (context.Request.QueryString.Equals(null))
                    await context.Response.WriteAsync($"{car?.GetCarModel()}");
                else
                {
                    try
                    {
                        int id = Convert.ToInt16(context.Request.QueryString.Value?.Substring(context.Request.QueryString.Value.IndexOf("=") + 1));
                        if (id <= Car.carsList.Count && id >= 1) 
                            await context.Response.WriteAsync($"{car?.GetCarModel(id)}");
                        else await context.Response.WriteAsync($"Exception: Incorrect ID. Please use ID values between '1' and '{Car.carsList.Count}'");
                    }
                    catch (FormatException ex)
                    {
                        await context.Response.WriteAsync($"ID Format Exception: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        await context.Response.WriteAsync($"Exception: {ex.Message}");
                    }
                }
            });
        }
        private static void GetCarsAges(IApplicationBuilder app)
        {
            var car = app.ApplicationServices.GetService<IManagementCars>();
            app.Run(async context =>
            {
                if (context.Request.QueryString.Equals(null))
                    await context.Response.WriteAsync($"{car?.GetCarAge()}");
                else
                {
                    try
                    {
                        int id = Convert.ToInt16(context.Request.QueryString.Value?.Substring(context.Request.QueryString.Value.IndexOf("=") + 1));
                        if (id <= Car.carsList.Count && id >= 1)
                            await context.Response.WriteAsync($"{car?.GetCarAge(id)}");
                        else await context.Response.WriteAsync($"Exception: Incorrect ID. Please use ID values between '1' and '{Car.carsList.Count}'");
                    }
                    catch (FormatException ex)
                    {
                        await context.Response.WriteAsync($"ID Format Exception: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        await context.Response.WriteAsync($"Exception: {ex.Message}");
                    }
                }
            });
        }
        private static void GetCarsEngines(IApplicationBuilder app)
        {
            var car = app.ApplicationServices.GetService<IManagementCars>();
            app.Run(async context =>
            {
                if (context.Request.QueryString.Equals(null))
                    await context.Response.WriteAsync($"{car.GetCarEngine()}");
                else 
                {
                    try
                    {
                        int id = Convert.ToInt16(context.Request.QueryString.Value?.Substring(context.Request.QueryString.Value.IndexOf("=") + 1));
                        if (id <= Car.carsList.Count && id >= 1) 
                            await context.Response.WriteAsync($"{car.GetCarEngine(id)}");
                        else await context.Response.WriteAsync($"Exception: Incorrect ID. Please use ID values between '1' and '{Car.carsList.Count}'");
                    }
                    catch (FormatException ex)
                    {
                        await context.Response.WriteAsync($"ID Format Exception: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        await context.Response.WriteAsync($"Exception: {ex.Message}");
                    }
                }
            });
        }
        private static void GetMenu(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("\t *** Map ***\n\n" +
                    " - .../all             - get all cars info\n" +
                    " - .../models          - get all distinct cars models\n" +
                    $" - .../models/?id=N    - get model of car with ID=N (please change the 'N' to desired ID values between '1' and '{Car.carsList.Count}')\n" +
                    " - .../ages            - get all distinct cars ages\n" +
                    $" - .../ages/?id=N      - get age of car with ID=N (please change the 'N' to desired ID values between '1' and '{Car.carsList.Count}')\n" +
                    " - .../engines         - get all distinct cars engines\n" +
                    $" - .../engines/?id=N   - get engine of car with ID=N (please change the 'N' to desired ID values between '1' and '{Car.carsList.Count}')\n");
            });
        }
    }   
}