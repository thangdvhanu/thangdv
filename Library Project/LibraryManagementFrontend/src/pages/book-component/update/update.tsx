import axios from "axios";
import React, { useEffect, useState } from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useHistory, useParams } from "react-router-dom";
import { BookService } from "../../../services/BookService";
import { CategoryService } from "../../../services/CategoryService";
import { Book, BookInput } from "../../../types/book";
import { Category } from "../../../types/category";

export function UpdateBook() {
  const { bookId } = useParams<any>();
  const bookService = new BookService();
  const cateService = new CategoryService();

  const [book, setBook] = useState<Book>();
  useEffect(() => {
    (async () => {
      let book = await bookService.getBook(bookId);
      setBook(book);
    })();
  }, []);

  const [categories, setCategory] = useState<Category[]>([]);
  useEffect(() => {
    (async () => {
      let categories = await cateService.getCategories();
      setCategory(categories);
    })();
  }, []);
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors }
  }
    = useForm<BookInput>({
      mode: 'onTouched'
    });

  useEffect(() => {
    reset(book);
  }, [book])
  let history = useHistory();
  const onSubmit: SubmitHandler<BookInput> = (data: BookInput) => {
    (async () => {
      await bookService.updateBook(data, bookId);
      history.push(`/details/book/${bookId}`);
    })();
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <label htmlFor="TitleCtrl">Title</label>
        <input {...register("title", { required: true })} type="text" className="form-control" placeholder="Enter book's title..."></input>
        {errors.title?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
        <label htmlFor="ShortContentCtrl">Short Content</label>
        <input {...register("shortContent", { required: true })} type="text" className="form-control" placeholder="Enter book's short content..."></input>
        {errors.shortContent?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
        <label htmlFor="UrlCtrl">Url</label>
        <input {...register("url", { required: true })} type="text" className="form-control" placeholder="Enter book image's url..."></input>
        {errors.url?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
      </div>
      <div className="custom-select" style={{ width: 200 }}>
        <h5>Category</h5>
        <select {...register("categoryId", { required: true })} >
          {
            categories &&
            categories.length > 0 &&
            categories.map((category: Category) =>
            (
              <option key={category.id} value={category.id}>{category.name}</option>
            ))
          }
        </select>
      </div>
      <br></br>
      <button type="submit" className="btn btn-primary">Update</button>
    </form>
  );
}
