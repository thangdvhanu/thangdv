import { Book, BookInput } from "../types/book";
import { HttpClient } from "./http-client";

export class BookService extends HttpClient{
  public constructor() {
    super('https://localhost:5001');
  }

  public getBooks = () => this.instance.get<Book[]>('/api/book');

  public getBook = (id: number) => this.instance.get<Book>(`/api/book/${id}`);

  public deleteBook = (id: number) => this.instance.delete<Book>(`/api/book/${id}`);

  public createBook = (book: BookInput) => this.instance.post<Book>("/api/book", book);

  public updateBook = (book: BookInput, id: number) => this.instance.put<Book>(`/api/book/${id}`, book);
}
