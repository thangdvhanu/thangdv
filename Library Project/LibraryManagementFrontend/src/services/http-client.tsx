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

  private _handleResponse = ({ data }: AxiosResponse) => {
    console.log(data);
    return data;
  };

  protected _handleError = (error: any) => {
    if (error.response.status === StatusCode.ClientErrorUnauthorized) {
      console.log("403 Unauthorized!");
      window.location.replace("/login");
    }
    else if (error.response.status === StatusCode.ClientErrorNotFound) {
      console.log("400 Not Found!");
      window.location.replace("/400-not-found");
    }
    else if (error.response.status === StatusCode.ClientErrorAccessDenied) {
      console.log("401 Access Denied!");
      window.location.replace("/401-access-denied");
    }
  };
}
