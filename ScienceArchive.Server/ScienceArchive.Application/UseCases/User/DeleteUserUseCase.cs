using System;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Application.UseCases
{
	public class DeleteUserUseCase
	{
		private IUserRepository _userRepository;

		public DeleteUserUseCase(
			IUserRepository userRepository
		)
		{
			_userRepository = userRepository;
		}

		public async Task<Guid> Execute(Guid userId)
		{
			return await _userRepository.Delete(userId);
		}
	}
}

