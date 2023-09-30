import { IdentifiedUser } from "@models/user/identified-user";

export interface GetUserByIdResponse {
  /**
   * Requested user
   */
  user: IdentifiedUser;
}
