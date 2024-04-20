using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.GeneralEntities.Repositories;

namespace Shop.Application.GeneralEntities.Banner.Create
{
    public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IFileService _localFileService;

        public CreateBannerCommandHandler(IBannerRepository bannerRepository,
            IFileService localFileService)
        {
            _bannerRepository = bannerRepository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            var banner = new Domain.GeneralEntities.Banner(request.Link, imageName, request.Position);
            await _bannerRepository.AddAsync(banner);
            await _bannerRepository.Save();
            return OperationResult.Success();
        }
    }
}
