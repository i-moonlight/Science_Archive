/**
 * Represents user data
 */
export interface User {
  /**
   * User name
   */
  name: string;

  /**
   * User email
   */
  email: string;

  /**
   * Login of user
   */
  login: string;

  /**
   * List of identifiers of roles
   */
  rolesIds: string[];
}
