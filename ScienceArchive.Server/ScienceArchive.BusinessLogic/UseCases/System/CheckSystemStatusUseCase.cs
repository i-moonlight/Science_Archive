using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.ValueObjects;
using ScienceArchive.Core.Services.SystemContracts;

namespace ScienceArchive.BusinessLogic.UseCases.System;

internal class CheckSystemStatusUseCase : IUseCase<SystemStatus, CheckSystemStatusContract>
{
    public Task<SystemStatus> Execute(CheckSystemStatusContract contract)
    {
        var systemStatus = new SystemStatus()
        {
            IsWorking = true,
        };

        return Task.FromResult(systemStatus);
    }
}