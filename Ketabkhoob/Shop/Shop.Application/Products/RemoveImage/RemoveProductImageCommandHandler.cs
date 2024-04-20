using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {

        private readonly IProductRepository _productRepository;
        private readonly IFileService _localFileService;

        public RemoveProductImageCommandHandler(IProductRepository productRepository,
            IFileService localFileService)
        {
            _productRepository = productRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var product =await _productRepository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);
            await _productRepository.Save();
            _localFileService.DeleteFile(Directories.ProductsGalleryImages,imageName);
            return OperationResult.Success();
        }
    }
}
