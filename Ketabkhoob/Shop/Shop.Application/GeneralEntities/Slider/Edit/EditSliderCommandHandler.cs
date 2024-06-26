﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.GeneralEntities.Repositories;

namespace Shop.Application.GeneralEntities.Slider.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IFileService _localFileService;

        public EditSliderCommandHandler(ISliderRepository sliderRepository,
            IFileService localFileService)
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
            var oldImage = slider.ImageName;
            if(request.ImageFile !=null)
            {
                imageName =await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            }
            slider.Edit(request.Title,request.Link,imageName);
            await _sliderRepository.Save();
            DeleteOldImage(request.ImageFile,oldImage);
            return OperationResult.Success();
        }
        private void DeleteOldImage(IFormFile? imageFile,string oldImage)
        {
            if (imageFile == null) return;
            _localFileService.DeleteFile(Directories.SliderImages, oldImage);
        }

    }
}
