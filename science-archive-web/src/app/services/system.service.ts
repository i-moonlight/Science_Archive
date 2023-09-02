import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Response } from "@models/common/response";
import CheckSystemStatusResponse from "@models/system/responses/check-system-status.response";

@Injectable({
  providedIn: "root",
})
export class SystemService {
  constructor(private httpClient: HttpClient) {}

  public checkSystemStatus(): Observable<Response<CheckSystemStatusResponse>> {
    return this.httpClient.get<Response<CheckSystemStatusResponse>>("/api/system/check-status");
  }
}
