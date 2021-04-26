import { Book } from "../types/book";
import { Request } from "../types/request";
import { HttpClient } from "./http-client";

export class RequestService extends HttpClient {
  public constructor() {
    super('https://localhost:5001');
  }

  public getRequests = () => this.instance.get<Request[]>('/api/request');

  public getRequest = (id: number) => this.instance.get<Request>(`/api/request/${id}`);

  public getRequestByUserId = (id: string) => this.instance.get<Request[]>(`/request/user/${id}`);

  public aprrove = (userId: string, id: number) => this.instance.post(`/api/Request/${userId}/approve/${id}`);

  public reject = (userId: string, id: number) => this.instance.post(`/api/Request/${userId}/reject/${id}`);

  public createRequest = (userId: string, bookIds: number[]) => this.instance.post(`/api/request/${userId}`, bookIds);

}
