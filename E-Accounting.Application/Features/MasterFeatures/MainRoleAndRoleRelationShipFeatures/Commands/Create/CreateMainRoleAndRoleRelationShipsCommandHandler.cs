using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Create
{
    public sealed record CreateMainRoleAndRoleRelationShipCommandHandler : ICommandHandler<CreateMainRoleAndRoleRelationShipCommand, CreateMainRoleAndRoleRelationShipsCommandResponse>
    {
        private readonly IMainRoleAndRoleRelationShipService _service;

        public CreateMainRoleAndRoleRelationShipCommandHandler(IMainRoleAndRoleRelationShipService service)
        {
            _service = service;
        }

        public async Task<CreateMainRoleAndRoleRelationShipsCommandResponse> Handle(CreateMainRoleAndRoleRelationShipCommand request, CancellationToken cancellationToken)
        {
            MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated = await _service.GetByRoleIdAndMainRoleId(request.RoleId, request.MainRoleId, cancellationToken);

            if (checkRoleAndMainRoleIsRelated != null)
            {
                throw new Exception("Bu rol ilişkisi daha önce kurulmuş");
            }
            MainRoleAndRoleRelationship mainRoleAndRoleRelationship = new(
                Guid.NewGuid().ToString(),
                request.RoleId,
                request.MainRoleId);

            await _service.CreateAsync(mainRoleAndRoleRelationship, cancellationToken);

            return new();
        }
    }
}
