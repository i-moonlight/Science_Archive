import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SignInRequest } from "../models/requests/sign-in.request";
import { SignUpRequest } from "../models/requests/sign-up.request";
import { Response } from "../models/responses/response";
import { SignUpResponseData } from "../models/responses/response-data/sign-up.response";
import { SignInResponseData } from "../models/responses/response-data/sign-in.response";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  signIn(request: SignInRequest): Observable<Response<SignInResponseData>> {
    return this.httpClient.post<Response<SignInResponseData>>("/api/auth/signin", request);
  }

  signUp(request: SignUpRequest): Observable<Response<SignUpResponseData>> {
    return this.httpClient.post<Response<SignUpResponseData>>("/api/auth/signup", request);
  }
}
