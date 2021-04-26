import axios, { AxiosInstance, AxiosResponse } from 'axios';
import { StatusCode } from './status-code-enum';

declare module 'axios' {
  interface AxiosResponse<T = any> extends Promise<T> { }
}

export abstract class HttpClient {
  protected readonly instance: AxiosInstance;

  public constructor(baseURL: string) {
    this.instance = axios.create({
      baseURL,
      withCredentials: true
    });

    this._initializeResponseInterceptor();
  }

  private _initializeResponseInterceptor = () => {
    this.instance.interceptors.response.use(
      this._handleResponse,
      this._handleError,
    );
  };

  private _handleResponse = ({ data }: AxiosResponse) => data;

  protected _handleError = (error: any) => {
    if (error.response.status === StatusCode.ClientErrorUnauthorized) {
      console.log("401 Unauthorized!");
    }
    else if (error.response.status === StatusCode.ClientErrorNotFound) {
      console.log("404 Not Found!");
    }
  };
}
