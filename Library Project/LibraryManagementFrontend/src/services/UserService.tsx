import { User, UserOnRegister } from "../types/user";
import { HttpClient } from "./http-client";

export class UserService extends HttpClient{
  public constructor() {
    super('https://localhost:5001');
  }

  public register = (user: UserOnRegister) => this.instance.post<User>("/register", user);

}
