/**
 * Represents user data
 */
interface UserResponseData {
  /**
   * User ID
   */
  id: string;

  /**
   * User name
   */
  name: string;

  /**
   * User login
   */
  login: string;

  /**
   * User email
   */
  email: string;
}

/**
 * Represents response to get all users from API
 */
export interface GetAllUsersResponseData {
  /**
   * All existing users
   */
  users: UserResponseData[];
}
