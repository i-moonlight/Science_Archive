import { User } from "@models/user/user";

export interface SignUpRequest {
  user: User;
  password: string;
}
