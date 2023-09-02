import { IdentifiedUser } from "@models/user/identified-user";

/**
 * Represents response to get all users from API
 */
export interface GetAllUsersResponse {
  /**
   * All existing users
   */
  users: IdentifiedUser[];
}
