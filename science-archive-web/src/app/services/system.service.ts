import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Response } from "@models/common/response";
import CheckSystemStatusResponse from "@models/system/responses/check-system-status.response";
import { ApiService } from "@services/api.service";

@Injectable({
  providedIn: "root",
})
export class SystemService extends ApiService {
  constructor(private httpClient: HttpClient) {
    super();
  }

  public checkSystemStatus(): Observable<CheckSystemStatusResponse> {
    const response = this.httpClient.get<Response<CheckSystemStatusResponse>>("/api/system/check-status");
    return this.handleResponse(response);
  }
}
