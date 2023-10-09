import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Response } from "@models/common/response";
import { GetAllNewsResponse } from "@models/news/responses/get-all-news.response";
import { Observable } from "rxjs";
import { GetNewsByIdResponse } from "@models/news/responses/get-news-by-id.response";
import { ApiService } from "@services/api.service";
import { News } from "@models/news/news";
import CreateNewsResponse from "@models/news/responses/create-news.response";
import createNewsRequest from "@models/news/requests/create-news.request";

@Injectable({
  providedIn: "root",
})
export class NewsService extends ApiService {
  constructor(private readonly httpClient: HttpClient) {
    super();
  }

  getAllNews(): Observable<GetAllNewsResponse> {
    const response = this.httpClient.get<Response<GetAllNewsResponse>>("/api/news/");
    return this.handleResponse(response);
  }

  getNewsById(id: string): Observable<GetNewsByIdResponse> {
    const response = this.httpClient.get<Response<GetNewsByIdResponse>>(`/api/news/${id}`);
    return this.handleResponse(response);
  }

  createNews(dto: createNewsRequest) {
    const response = this.httpClient.post<Response<CreateNewsResponse>>("/api/news/create", dto);
    return this.handleResponse(response);
  }
}
