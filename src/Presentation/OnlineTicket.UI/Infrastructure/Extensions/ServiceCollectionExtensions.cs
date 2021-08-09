using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineTicket.Clients.OBilet;
using OnlineTicket.Clients.OBilet.HttpHandlers;
using OnlineTicket.Services;
using OnlineTicket.UI.Behaviours;
using Refit;
using System;
using System.Reflection;

namespace OnlineTicket.UI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOnlineTicketSession();
            services.AddOnlineTicketControllersWithViews();
            services.AddOnlineTicketRefitClients(configuration);
            services.AddOnlineTicketSession();
            services.RegisterServices();
            services.AddOnlineTicketHttpContextAccessor();
            services.AddOnlineTicketAutoMapper();
            services.AddOnlineTicketMediatR();
            services.AddOnlineTicketFluentValidation();
            services.AddOnlineTicketDetection();
            services.AddOnlineTicketMemoryCache();
        }

        private static void AddOnlineTicketSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
            });
        }

        private static void AddOnlineTicketControllersWithViews(this IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        private static void AddOnlineTicketRefitClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IObiletApiClient>()
                .ConfigureHttpClient(x =>
                {
                    x.BaseAddress = new Uri(configuration["Obilet:BaseUrl"]);
                }).AddHttpMessageHandler<AuthenticationHeaderHandler>();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<AuthenticationHeaderHandler>();
            services.AddTransient<IDeviceSessionService, DeviceSessionService>();
            services.AddTransient<IBusLocationsService, BusLocationsService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DeviceSessionBehaviour<,>));

            services.AddScoped<IVisitorService, VisitorService>();
        }

        private static void AddOnlineTicketHttpContextAccessor(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }

        private static void AddOnlineTicketFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        private static void AddOnlineTicketAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddOnlineTicketDetection(this IServiceCollection services)
        {
            services.AddDetection();
        }

        private static void AddOnlineTicketMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void AddOnlineTicketMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}