import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from "../models/responses/response";
import { GetAllUsersResponseData } from "../models/responses/response-data/get-all-users.response";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor (private httpClient: HttpClient) {}

  public getAllUsers(): Observable<Response<GetAllUsersResponseData>> {
    return this.httpClient.get<Response<GetAllUsersResponseData>>('/api/users/');
  }
}
