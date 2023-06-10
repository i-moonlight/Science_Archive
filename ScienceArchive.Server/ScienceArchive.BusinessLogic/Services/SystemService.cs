using System;
using ScienceArchive.Core.Domain.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.SystemContracts;

namespace ScienceArchive.BusinessLogic.Services
{
    public class SystemService : BaseService, ISystemService
    {
        public SystemService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<SystemStatus> CheckSystemStatus(CheckSystemStatusContract contract)
        {
            return await ExecuteUseCase<SystemStatus, CheckSystemStatusContract>(contract);
        }
    }
}

