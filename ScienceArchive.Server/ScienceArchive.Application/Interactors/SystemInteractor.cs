using ScienceArchive.Application.Dtos.System.Request;
using ScienceArchive.Application.Dtos.System.Response;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.SystemContracts;

namespace ScienceArchive.Application.Interactors;

internal class SystemInteractor : ISystemInteractor
{
    private readonly ISystemService _systemService;

    public SystemInteractor(ISystemService systemService)
    {
        _systemService = systemService ?? throw new ArgumentNullException(nameof(systemService));
    }

    /// <inheritdoc/>
    public async Task<CheckSystemStatusResponseDto> CheckSystemStatus(CheckSystemStatusRequestDto dto)
    {
        var contract = new CheckSystemStatusContract();
        var systemStatus = await _systemService.CheckSystemStatus(contract);

        return new(systemStatus.IsWorking);
    }
}