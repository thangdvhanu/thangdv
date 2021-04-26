import { Category, CategoryInput } from "../types/category";
import { HttpClient } from "./http-client";

export class CategoryService extends HttpClient {

  public constructor() {
    super("https://localhost:5001");
  }

  public getCategories = () => this.instance.get<Category[]>("/api/category");

  public getCategory = (id: number) => this.instance.get<Category>(`/api/category/${id}`);

  public deleteCategory = (id: number) => this.instance.delete<Category>(`/api/category/${id}`);

  public createCategory = (category: CategoryInput) => this.instance.post<Category>("/api/category", category);

  public updateCategory = (category: CategoryInput, id: number) => this.instance.put<Category>(`/api/category/${id}`, category);

}
