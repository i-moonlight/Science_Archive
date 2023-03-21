/**
 * Represent data given from server to sign up request
 */
export interface SignUpResponseData {
  /**
   * Created user ID
   */
  id: string;

  /**
   * Created user name
   */
  name: string;

  /**
   * Created user login
   */
  login: string;

  /**
   * Created user email
   */
  email: string;
}
