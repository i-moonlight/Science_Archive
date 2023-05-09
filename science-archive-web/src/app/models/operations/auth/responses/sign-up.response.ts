import { IdentifiedUser } from "@models/user/identified-user";

/**
 * Represent data given from server to sign up request
 */
export interface SignUpResponse {
  /**
   * New created user
   */
  user: IdentifiedUser;
}
