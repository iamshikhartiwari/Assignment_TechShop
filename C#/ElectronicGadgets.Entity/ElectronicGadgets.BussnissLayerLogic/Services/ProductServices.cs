using ElectronicGadgets.BussnissLayerLogic.Repository;
using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Services;


namespace ElectronicGadgets.BussnissLayerLogic.Repository;

public class ProductServices(IProductService productService)
{
    private readonly IProductRepository _productRepository;

    public void GetProductDetails(int productId)
    {
        productService.GetProductDetails(productId);
    }

    public void UpdateProductInfo(int productId, decimal newPrice, string newDescription)
    {
        productService.UpdateProductInfo(productId, newPrice, newDescription);
    }

    public bool IsProductInStock(int productId)
    {
        productService.IsProductInStock(productId);
    }
}
