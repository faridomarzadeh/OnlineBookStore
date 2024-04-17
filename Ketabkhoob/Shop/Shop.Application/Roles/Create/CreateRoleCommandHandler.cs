using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(x => permissions.Add(new RolePermission(x)));
            var role = new Role(request.Title, permissions);
            await _roleRepository.Add(role);
            await _roleRepository.Save();
            return OperationResult.Success();
        }
    }
}
