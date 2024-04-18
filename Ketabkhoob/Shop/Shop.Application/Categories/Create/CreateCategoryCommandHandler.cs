using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _categoryDomainService;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService categoryDomainService)
        {
            _repository = repository;
            _categoryDomainService = categoryDomainService;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Title, request.Slug, request.SeoData, _categoryDomainService);
            await _repository.AddAsync(category);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
