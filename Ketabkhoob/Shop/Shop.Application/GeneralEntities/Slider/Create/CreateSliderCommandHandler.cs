using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.GeneralEntities;
using Shop.Domain.GeneralEntities.Repositories;

namespace Shop.Application.GeneralEntities.Slider.Create
{
    public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly ILocalFileService _localFileService;

        public CreateSliderCommandHandler(ISliderRepository sliderRepository,
            ILocalFileService localFileService)
        {
            _sliderRepository = sliderRepository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Domain.GeneralEntities.Slider(request.Title, request.Link, imageName);
            _sliderRepository.Add(slider);
            await _sliderRepository.Save();
            return OperationResult.Success();
        }
    }
}
