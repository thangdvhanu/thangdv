import { Book } from "./book";
import { User } from "./user";

export type Request = {
  id: number,
  status: number,
  requestUser: User,
  requestDate: Date,
  requestDetails: Detail[]
}

export type Detail = {
  id: number,
  book: Book
}
