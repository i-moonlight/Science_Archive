/**
 * Represent response from API
 */
export interface Response<T> {
  /**
   * Success status of response
   */
  success: boolean;

  /**
   * Data returned from API
   */
  data: T | null;

  /**
   * Error accured while processing request
   */
  error: string | null;
}
