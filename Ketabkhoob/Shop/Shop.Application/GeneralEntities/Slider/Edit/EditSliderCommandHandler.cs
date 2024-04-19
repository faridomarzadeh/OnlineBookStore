using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.GeneralEntities.Repositories;

namespace Shop.Application.GeneralEntities.Slider.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly ILocalFileService _localFileService;

        public EditSliderCommandHandler(ISliderRepository sliderRepository,
            ILocalFileService localFileService)
        {
            _sliderRepository = sliderRepository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider =await _sliderRepository.GetTracking(request.SliderId);
            if (slider == null)
                return OperationResult.NotFound();
            
            var imageName = slider.ImageName;
            if(request.ImageFile !=null)
            {
                imageName =await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            }
            slider.Edit(request.Title,request.Link,imageName);
            await _sliderRepository.Save();
            return OperationResult.Success();
        }

    }
}
