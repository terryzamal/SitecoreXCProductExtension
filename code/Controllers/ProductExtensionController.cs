using Sitecore.Commerce.XA.Foundation.Common.Context;
using Sitecore.Commerce.XA.Foundation.Common.Controllers;
using Sitecore.Commerce.XA.Foundation.Common.Providers;
using Sitecore.Commerce.XA.Foundation.Connect;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using SitecoreXC92.ProductExtension.Models;
using SitecoreXC92.ProductExtension.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SitecoreXC92.ProductExtension.Controllers
{
    [SessionState(SessionStateBehavior.ReadOnly)]
    public class ProductExtensionController : BaseCommerceStandardController
    {
        public IProductExtensionRepository ProductExtensionRepository { get; private set; }
        public ISiteContext SiteContext { get; private set; }
        public IItemTypeProvider ItemTypeProvider { get; private set; }
        public IVisitorContext _visitorContext { get; set; }
        public ProductExtensionController(IProductExtensionRepository ProductExtensionRepository, ISiteContext siteContext, 
            IItemTypeProvider itemTypeProvider, IStorefrontContext storefrontContext, IContext sitecoreContext,IVisitorContext visitorContext)
        : base(storefrontContext, sitecoreContext)
        {
            Assert.ArgumentNotNull(ProductExtensionRepository, "ProductExtensionRepository");
            Assert.ArgumentNotNull(siteContext, "siteContext");
            Assert.ArgumentNotNull(itemTypeProvider, "itemTypeProvider");
            this.ProductExtensionRepository = ProductExtensionRepository;
            this.SiteContext = siteContext;
            this.ItemTypeProvider = itemTypeProvider;
            this._visitorContext = visitorContext;
        }
        public ActionResult Load()
        {
            IProductExtensionRepository ProductExtensionRepository = this.ProductExtensionRepository;
            //IVisitorContext service = ServiceLocator.ServiceProvider.GetService(typeof(IVisitorContext));
            ProductExtensionRenderingModel productTypeModel = ProductExtensionRepository.GetProductTypeModel(this._visitorContext);
            return base.View("~/Views/Commerce/ProductExtension/ProductExtension.cshtml", productTypeModel);
        }

        // GET: ProductType
    }
}