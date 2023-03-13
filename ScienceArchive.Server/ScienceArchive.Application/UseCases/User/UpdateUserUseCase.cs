using System;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Application.UseCases
{
	public class UpdateUserUseCase
	{
		private IUserRepository _userRepository;

		public UpdateUserUseCase(
			IUserRepository userRepository
		)
		{
			_userRepository = userRepository;
		}

		public async Task<User> Execute(Guid userId, User user)
		{
			return await _userRepository.Update(userId, user);
		}
	}
}

