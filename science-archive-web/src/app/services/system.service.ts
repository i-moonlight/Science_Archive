import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from "../models/responses/response";
import CheckSystemStatusResponseData from "../models/responses/response-data/check-system-status.response";

@Injectable({
  providedIn: "root",
})
export class SystemService {
  constructor(private httpClient: HttpClient) {}

  public checkSystemStatus(): Observable<Response<CheckSystemStatusResponseData>> {
    return this.httpClient.get<Response<CheckSystemStatusResponseData>>("/api/system/check-status");
  }
}
