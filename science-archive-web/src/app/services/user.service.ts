import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from "@models/common/response";
import { GetAllUsersResponse } from "@models/user/responses/get-all-users.response";
import { GetAllAuthorsResponse } from "@models/user/responses/get-all-authors.response";
import { ApiService } from "@services/api.service";
import { GetUserByIdResponse } from "@models/user/responses/get-user-by-id.response";

@Injectable({
  providedIn: "root",
})
export class UserService extends ApiService {
  constructor(private httpClient: HttpClient) {
    super();
  }

  public getAllUsers(): Observable<GetAllUsersResponse> {
    const response = this.httpClient.get<Response<GetAllUsersResponse>>("/api/users/");
    return this.handleResponse(response);
  }

  public getAllAuthors(): Observable<GetAllAuthorsResponse> {
    const response = this.httpClient.get<Response<GetAllAuthorsResponse>>("/api/users/get-authors");
    return this.handleResponse(response);
  }

  public getUserById(userId: string): Observable<GetUserByIdResponse> {
    const response = this.httpClient.get<Response<GetUserByIdResponse>>(`/api/users/${userId}`);
    return this.handleResponse(response);
  }
}
