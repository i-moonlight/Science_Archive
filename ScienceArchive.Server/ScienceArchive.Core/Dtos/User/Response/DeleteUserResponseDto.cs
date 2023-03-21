using System;
namespace ScienceArchive.Core.Dtos.UserResponse
{
	public record class DeleteUserResponseDto
	{
		/// <summary>
		/// ID of the deleted user
		/// </summary>
		public required Guid Id { get; set; }
	}
}

