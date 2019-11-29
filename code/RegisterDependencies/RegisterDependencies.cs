using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreXC92.ProductExtension.Controllers;
using SitecoreXC92.ProductExtension.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreXC92.ProductExtension.RegisterDependencies
{
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ProductExtensionController>();
            serviceCollection.AddTransient<IProductExtensionRepository, ProductExtensionRepository>();
        }
    }
}