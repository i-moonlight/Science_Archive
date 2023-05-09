import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SignInRequest } from "@models/operations/auth/requests/sign-in.request";
import { SignUpRequest } from "@models/operations/auth/requests/sign-up.request";
import { Response } from "@models/operations/response";
import { SignUpResponse } from "@models/operations/auth/responses/sign-up.response";
import { SignInResponse } from "@models/operations/auth/responses/sign-in.response";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  signIn(request: SignInRequest): Observable<Response<SignInResponse>> {
    return this.httpClient.post<Response<SignInResponse>>("/api/auth/sign-in", request);
  }

  signUp(request: SignUpRequest): Observable<Response<SignUpResponse>> {
    return this.httpClient.post<Response<SignUpResponse>>("/api/auth/sign-up", request);
  }
}
