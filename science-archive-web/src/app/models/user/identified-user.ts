import { User } from "./user";

/**
 * Identified user, i.e. user which has own identifier
 */
export interface IdentifiedUser extends User {
  /**
   * User ID
   */
  id: string;

  /**
   * Is current user admin
   */
  isAdmin: boolean;
}
