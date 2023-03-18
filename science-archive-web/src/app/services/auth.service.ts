import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SignInRequest } from "../models/requests/sign-in.request";
import { SignUpRequest } from "../models/requests/sign-up.request";
import { Response } from "../models/responses/response";
import { SignUpResponseData } from "../models/responses/response-data/sign-up.response";
import { TokenResponseData } from "../models/responses/response-data/token.response";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  signin(request: SignInRequest): Observable<Response<TokenResponseData>> {
    return this.httpClient.post<Response<TokenResponseData>>("/api/auth/signin", request);
  }

  signup(request: SignUpRequest): Observable<Response<SignUpResponseData>> {
    return this.httpClient.post<Response<SignUpResponseData>>("/api/auth/signup", request);
  }
}
