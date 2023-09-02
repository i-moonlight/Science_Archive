import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Response } from "@models/common/response";
import { GetAllNewsResponse } from "@models/news/responses/get-all-news.response";
import { Observable } from "rxjs";
import { GetNewsByIdResponse } from "@models/news/responses/get-news-by-id.response";

@Injectable({
  providedIn: "root",
})
export class NewsService {
  constructor(private readonly httpClient: HttpClient) {}

  getAllNews(): Observable<Response<GetAllNewsResponse>> {
    return this.httpClient.get<Response<GetAllNewsResponse>>("/api/news/");
  }

  getNewsById(id: string): Observable<Response<GetNewsByIdResponse>> {
    return this.httpClient.get<Response<GetNewsByIdResponse>>(`/api/news/${id}`);
  }
}
