/**
 * User which has articles (author)
 */
export interface AuthorUser {
  /**
   * User ID
   */
  id: string;

  /**
   * Name of a user
   */
  name: string;

  /**
   * Description of author
   */
  description: string;

  /**
   * Identifiers of articles
   */
  articlesIds: string[];
}
