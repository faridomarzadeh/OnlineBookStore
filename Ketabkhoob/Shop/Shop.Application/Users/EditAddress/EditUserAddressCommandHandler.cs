using Common.Application;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditUserAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.EditAddress(request.UserId, request.Province,request.City,
                request.PostalCode, request.MailingAddress,request.PhoneNumber,
                request.Name,request.Family,request.NationalID);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
