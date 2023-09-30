import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SignInRequest } from "@models/auth/requests/sign-in.request";
import { SignUpRequest } from "@models/auth/requests/sign-up.request";
import { Response } from "@models/common/response";
import { SignUpResponse } from "@models/auth/responses/sign-up.response";
import { SignInResponse } from "@models/auth/responses/sign-in.response";
import { ApiService } from "@services/api.service";

@Injectable({
  providedIn: "root",
})
export class AuthService extends ApiService {
  constructor(private httpClient: HttpClient) {
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
}
