import { IdentifiedUser } from "@models/user/identified-user";

/**
 * Represent sign in response data
 */
export interface SignInResponse {
  /**
   * Authorization token generated by API
   */
  token: string;

  /**
   * Authenticated user
   */
  user: IdentifiedUser;
}
