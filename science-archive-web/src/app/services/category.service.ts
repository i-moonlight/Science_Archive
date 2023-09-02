import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Response } from "@models/common/response";
import { GetAllCategoriesResponse } from "@models/category/responses/get-all-categories.response";

@Injectable({
  providedIn: "root",
})
export class CategoryService {
  constructor(private httpClient: HttpClient) {}

  getAllArticles(): Observable<Response<GetAllCategoriesResponse>> {
    return this.httpClient.get<Response<GetAllCategoriesResponse>>("/api/categories/");
  }
}
