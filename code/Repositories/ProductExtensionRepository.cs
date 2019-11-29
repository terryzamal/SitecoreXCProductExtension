using Sitecore.Commerce.XA.Feature.Catalog.Repositories;
using Sitecore.Commerce.XA.Foundation.Common.Context;
using Sitecore.Commerce.XA.Foundation.Common.Models;
using Sitecore.Commerce.XA.Foundation.Connect.Managers;
using Sitecore.Commerce.XA.Feature.Catalog.Models;
using Sitecore.Commerce.XA.Foundation.Common.Search;
using Sitecore.Commerce.XA.Foundation.Connect;
using SitecoreXC92.ProductExtension.Models;
using Sitecore.Diagnostics;
using Sitecore.Commerce.XA.Foundation.Catalog.Managers;

namespace SitecoreXC92.ProductExtension.Repositories
{
    public class ProductExtensionRepository : BaseCatalogRepository, IProductExtensionRepository
    {
        private ISiteContext siteContext;

        //public ProductExtensionRepository(ISiteContext siteContext, IModelProvider modelProvider, ISearchManager searchManager, 
        //    IStorefrontContext storefrontContext)
        //{
        //    this.siteContext = siteContext;
        //    this.ModelProvider = modelProvider;
        //    this.SearchManager = searchManager;
        //    this.StorefrontContext = storefrontContext;
        //    this.SetSiteContext(siteContext);
        //}

        public ProductExtensionRepository(IModelProvider modelProvider, IStorefrontContext storefrontContext, ISiteContext siteContext,
            ISearchInformation searchInformation, ISearchManager searchManager, ICatalogManager catalogManager, ICatalogUrlManager catalogUrlManager, 
            IContext context) : base(modelProvider, storefrontContext, siteContext, searchInformation, searchManager, catalogManager, catalogUrlManager, context)
        {
            Assert.ArgumentNotNull(modelProvider, "modelProvider");
            Assert.ArgumentNotNull(searchManager, "searchManager");
            Assert.ArgumentNotNull(storefrontContext, "storefrontContext");
            this.ModelProvider = modelProvider;
            this.SearchManager = searchManager;
            this.StorefrontContext = storefrontContext;
            this.SetSiteContext(siteContext);
        }



        protected ISiteContext GetSiteContext()
        {
            return siteContext;
        }

        private void SetSiteContext(ISiteContext value)
        {
            siteContext = value;
        }


        public ProductExtensionRenderingModel GetProductTypeModel(IVisitorContext visitorContext)
        {
            CatalogItemRenderingModel catalogItemRenderingModel = this.GetProduct(visitorContext);
            ProductExtensionRenderingModel productTypeRenderingModel = this.ModelProvider.GetModel<ProductExtensionRenderingModel>();
            productTypeRenderingModel.Initialize(catalogItemRenderingModel, false);
            return productTypeRenderingModel;
        }
    }
}