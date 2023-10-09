using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases;

public class GetUserClaimsUseCase : IUseCase<List<RoleClaim>, GetUserClaimsContract>
{
	private readonly IRoleRepository _roleRepository;
	
	public GetUserClaimsUseCase(IRoleRepository roleRepository)
	{
		_roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
	}
	
	public async Task<List<RoleClaim>> Execute(GetUserClaimsContract contract)
	{
		return await _roleRepository.GetUserClaims(contract.UserId);
	}
}