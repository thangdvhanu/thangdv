import React, { useEffect, useState } from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useHistory } from "react-router-dom";
import { BookService } from "../../../services/BookService";
import { CategoryService } from "../../../services/CategoryService";
import { BookInput } from "../../../types/book";
import { Category } from "../../../types/category";

export function CreateBook() {
  const [categories, setCategory] = useState<Category[]>([]);
  let history = useHistory();
  let cateService = new CategoryService();
  let bookService = new BookService();
  useEffect(() => {
    (async () => {
      let categories = await cateService.getCategories();
      setCategory(categories);
    })();
  }, []);
  const {
    register,
    handleSubmit,
    formState: { errors }
  }
    = useForm<BookInput>({
      mode: 'onTouched'
    });
  const onSubmit: SubmitHandler<BookInput> = (data: BookInput) => {
    (async () => {
      await bookService.createBook(data);
      history.push("/book");
    })();
  };
  return (
    <div>
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
        <button type="submit" className="btn btn-primary">Add</button>
      </form>
    </div>
  );
}
