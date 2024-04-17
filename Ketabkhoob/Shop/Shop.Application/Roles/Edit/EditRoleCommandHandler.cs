using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        public EditRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetTracking(request.RoleId);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(x=> permissions.Add(new RolePermission(x)));
            role.SetPermissions(permissions);
            await _roleRepository.Save();
            return OperationResult.Success();
        }
    }
}
