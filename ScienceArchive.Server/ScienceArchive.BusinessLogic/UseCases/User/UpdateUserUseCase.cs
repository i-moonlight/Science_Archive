﻿using System;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Services.UserContracts;
using ScienceArchive.Core.Repositories;

namespace ScienceArchive.BusinessLogic.UserUseCases
{
    public class UpdateUserUseCase : IUseCase<User, UpdateUserContract>
    {
        private IUserRepository _userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(UpdateUserContract contract)
        {
            return await _userRepository.Update(contract.Id, contract.User);
        }
    }
}
