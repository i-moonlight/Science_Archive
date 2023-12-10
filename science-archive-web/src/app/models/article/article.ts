/**
 * Article data
 */
export interface Article {
  /**
   * Identifier of the article
   */
  id: string;

  /**
   * Article title
   */
  title: string;

  /**
   * Identifier of the user
   * created the article
   */
  authorId: string;

  /**
   * Date when article was created
   */
  creationDate: Date;

  /**
   * Article description
   */
  description: string | null;

  /**
   * Paths to documents linked to article
   */
  documentsPaths: string[];

  /**
   * Current article status represented as number
   */
  status: number;
}
