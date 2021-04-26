import { Book, BookInput } from "../types/book";
import { User, UserLogin } from "../types/user";
import { HttpClient } from "./http-client";

export class AuthenticationSerivce extends HttpClient{
  public constructor() {
    super('https://localhost:5001');
  }

  public login = (user: UserLogin) => this.instance.post<User>("/login", user);

  public logout = ()=>this.instance.post("/logout");
}
