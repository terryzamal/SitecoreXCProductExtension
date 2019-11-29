using Sitecore.Commerce.XA.Foundation.Connect;
using SitecoreXC92.ProductExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreXC92.ProductExtension.Repositories
{
    public interface IProductExtensionRepository
    {
        ProductExtensionRenderingModel GetProductTypeModel(IVisitorContext visitorContext);
    }
}