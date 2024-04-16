using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.AddImage
{
    public class AddProductCommandImageHandler : IBaseCommandHandler<AddProductCommandImage>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILocalFileService _localFileService;

        public AddProductCommandImageHandler(IProductRepository productRepository,
            ILocalFileService localFileService)
        {
            _productRepository = productRepository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(AddProductCommandImage request, CancellationToken cancellationToken)
        {
           var product =await _productRepository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            var imageName =await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductsGalleryImages);
            product.AddImage(new ProductImage(imageName,request.Sequence));
            await _productRepository.Save();
            return OperationResult.Success();
        }
    }
}
