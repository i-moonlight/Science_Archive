using System;
namespace ScienceArchive.Core.Dtos.UserRequest
{
	public record class DeleteUserRequestDto
	{
		/// <summary>
		/// ID of the user to delete
		/// </summary>
		public required Guid Id { get; set; }
	}
}

