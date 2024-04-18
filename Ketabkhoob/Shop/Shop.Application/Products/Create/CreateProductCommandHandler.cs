using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainservice _productDomainservice;
        private readonly IProductRepository _productRepository;
        private readonly ILocalFileService _localFileService;
        public CreateProductCommandHandler(IProductDomainservice productDomainservice,
            IProductRepository productRepository, ILocalFileService localFileService)
        {
            _productDomainservice = productDomainservice;
            _productRepository = productRepository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName =await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product = new Product(request.Title,imageName,request.Description,request.CategoryId,
                request.SubCategoryId,request.SubSubCategoryId,request.Slug,request.SeoData,_productDomainservice);

            await _productRepository.AddAsync(product);

            var list = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                list.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecifications(list);
            await _productRepository.Save();
            return OperationResult.Success();
        }
    }
}
