import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SignInRequest } from "@models/auth/requests/sign-in.request";
import { SignUpRequest } from "@models/auth/requests/sign-up.request";
import { Response } from "@models/common/response";
import { SignUpResponse } from "@models/auth/responses/sign-up.response";
import { SignInResponse } from "@models/auth/responses/sign-in.response";
import { ApiService } from "@services/api.service";
import CheckAdminResponse from "@models/auth/responses/check-admin.response";
import CheckAdminRequest from "@models/auth/requests/check-admin.request";

@Injectable({
  providedIn: "root",
})
export class AuthService extends ApiService {
  constructor(private readonly httpClient: HttpClient) {
    super();
  }

  signIn(request: SignInRequest): Observable<SignInResponse> {
    const response = this.httpClient.post<Response<SignInResponse>>("/api/auth/sign-in", request);
    return this.handleResponse(response);
  }

  signUp(request: SignUpRequest): Observable<SignUpResponse> {
    const response = this.httpClient.post<Response<SignUpResponse>>("/api/auth/sign-up", request);
    return this.handleResponse(response);
  }

  checkAdmin(userId: string): Observable<CheckAdminResponse> {
    const request: CheckAdminRequest = { userId };
    const response = this.httpClient.post<Response<CheckAdminResponse>>("/api/auth/check-admin", request);
    return this.handleResponse(response);
  }
}
