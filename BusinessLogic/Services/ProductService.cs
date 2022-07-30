using BusinessLogic.Repositories.Interfaces;
using Common.DTO;

namespace BusinessLogic.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
}