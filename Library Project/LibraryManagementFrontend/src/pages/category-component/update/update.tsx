import React, { useEffect, useState } from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useHistory, useParams } from "react-router-dom";
import { CategoryService } from "../../../services/CategoryService";
import { Category, CategoryInput } from "../../../types/category";

export function UpdateCategory() {
  const [category, setCategory] = useState({});
  const { categoryId } = useParams<any>();
  let service = new CategoryService();

  useEffect(() => {
    (async () => {
      let category = await service.getCategory(categoryId);
      setCategory(category);
    })();
  }, []);
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors }
  }
    = useForm<CategoryInput>({
      mode: 'onTouched'
    });
  let history = useHistory();

  useEffect(() => {
    reset(category);
  }, [category])

  const onSubmit: SubmitHandler<CategoryInput> = (data: CategoryInput) => {
    (async () => {
      await service.updateCategory(data, categoryId);
      history.push("/category");
    })();
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <label htmlFor="NameCtrl">Name</label>
        <input {...register("name", { required: true, pattern: /^[a-zA-z ]+$/i })} type="text" className="form-control" placeholder="Enter category name..."></input>
        {errors.name?.type === "required" && <p style={{ color: 'red' }}>This field  is required!</p>}
        {errors.name?.type === "pattern" && <p style={{ color: 'red' }}>Only alphabet character included!</p>}
      </div>
      <button type="submit" className="btn btn-primary">Update</button>
    </form>
  );
}
