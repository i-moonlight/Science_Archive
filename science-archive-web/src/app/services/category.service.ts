import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Response } from "@models/common/response";
import { GetAllCategoriesResponse } from "@models/category/responses/get-all-categories.response";
import { ApiService } from "@services/api.service";

@Injectable({
  providedIn: "root",
})
export class CategoryService extends ApiService {
  constructor(private httpClient: HttpClient) {
    super();
  }

  getAllArticles(): Observable<GetAllCategoriesResponse> {
    const response = this.httpClient.get<Response<GetAllCategoriesResponse>>("/api/categories/");
    return this.handleResponse(response);
  }
}
