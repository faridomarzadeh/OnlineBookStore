using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductDomainservice _productDomainservice;
        private readonly IProductRepository _productRepository;
        private readonly ILocalFileService _localLocalFileService;

        public EditProductCommandHandler(IProductDomainservice productDomainservice,
            IProductRepository productRepository, ILocalFileService localLocalFileService)
        {
            _productDomainservice = productDomainservice;
            _productRepository = productRepository;
            _localLocalFileService = localLocalFileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
                request.SubSubCategoryId, request.Slug, request.SeoData, _productDomainservice);

            var oldImage = product.ImageName;

            if (request.ImageFile != null)
            {
                var imageName = await _localLocalFileService
                    .SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

                product.SetProductImage(imageName);
            }

            var list = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                list.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecifications(list);

            await _productRepository.Save();
            RemoveImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void RemoveImage(IFormFile newImageFile,string oldImageName)
        {
            if (newImageFile == null)
                return;

            _localLocalFileService.DeleteFile(Directories.ProductImages,oldImageName);
        }
    }
}
