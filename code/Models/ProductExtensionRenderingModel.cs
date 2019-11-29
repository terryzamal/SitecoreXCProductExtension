using Sitecore.Commerce.XA.Feature.Catalog.Models;
using Sitecore.Commerce.XA.Foundation.Common.Context;
using Sitecore.Commerce.XA.Foundation.Common.Models;
using Sitecore.Commerce.XA.Foundation.Common.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreXC92.ProductExtension.Models
{
    public class ProductExtensionRenderingModel : CatalogItemRenderingModel
    {
        public string ProductRegion { get; set; }
        public ProductExtensionRenderingModel(IStorefrontContext storefrontContext, IItemTypeProvider itemTypeProvider, IModelProvider modelProvider,
                IVariantDefinitionProvider variantDefinitionProvider) : base(storefrontContext, itemTypeProvider, modelProvider, variantDefinitionProvider)
        {
        }
        public void Initialize(CatalogItemRenderingModel catalogItemRenderingModel, bool initializeAsMock = false)
        {
            try
            {
                this.CatalogItem = catalogItemRenderingModel.CatalogItem;
                this.CatalogItem.Fields.ReadAll();
                this.ProductRegion = this.CatalogItem.Fields["Region"].Value;//Type is property which u had added
            }
            catch (Exception exception)
            {

                this.ProductRegion = "[There is no actual product data in experiance editor.]";
            }
        }
    }
}