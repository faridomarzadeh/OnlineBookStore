using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.GeneralEntities.Repositories;

namespace Shop.Application.GeneralEntities.Banner.Edit
{
    public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {

        private readonly IBannerRepository _bannerRepository;
        private readonly ILocalFileService _localFileService;

        public EditBannerCommandHandler(IBannerRepository bannerRepository,
            ILocalFileService localFileService)
        {
            _bannerRepository = bannerRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetTracking(request.BannerId);
            if (banner == null)
                return OperationResult.NotFound();
            var imageName = banner.ImageName;
            if (request.ImageFile != null)
                imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

            banner.Edit(request.Link, imageName, request.Position);
            await _bannerRepository.Save();
            return OperationResult.Success();
        }
    }
}
