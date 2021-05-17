import { Category } from "./category";

export type Book = {
  id: number,
  title: string,
  shortContent: string,
  url: string,
  category: Category
}

export type BookInput = {
  title: string,
  shortContent: string,
  url: string,
  categoryId: number
}
