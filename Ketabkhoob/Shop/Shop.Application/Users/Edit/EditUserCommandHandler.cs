using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Services;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;
        private readonly IFileService _localFileService;

        public EditUserCommandHandler(IUserRepository userRepository,
            IUserDomainService userDomainService,
            IFileService localFileService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.GetTracking(request.UsertId);
            if (user == null)
                return OperationResult.NotFound();
            var oldAvatar = user.AvatarName;
            user.Edit(request.Name,request.Family,request.PhoneNumber,request.Email,request.Gender,_userDomainService);
            if(request.Avatar != null)
            {
                var imageName =await _localFileService.SaveFileAndGenerateName(request.Avatar,Directories.UserAvatars);
                user.SetAvatar(imageName);
            }
            await _userRepository.Save();
            DeleteOldAvatar(request.Avatar, oldAvatar);
            return OperationResult.Success();
           
        }
        private void DeleteOldAvatar(IFormFile? file,string oldAvatar)
        {
            if(file == null || oldAvatar ==UserConstants.DefaultAvatarImage)
                return;

            _localFileService.DeleteFile(Directories.UserAvatars,oldAvatar);
        }
    }
}
