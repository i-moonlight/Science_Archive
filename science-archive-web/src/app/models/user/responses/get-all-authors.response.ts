import { AuthorUser } from "@models/user/author-user";

/**
 * Represents response to get all authors from API
 */
export interface GetAllAuthorsResponse {
  /**
   * All existing authors
   */
  authors: AuthorUser[];
}
