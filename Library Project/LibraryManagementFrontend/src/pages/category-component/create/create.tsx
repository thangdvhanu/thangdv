import React from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useHistory } from "react-router-dom";
import { CategoryService } from "../../../services/CategoryService";
import { CategoryInput } from "../../../types/category";

export function CreateCategory() {
  let service = new CategoryService();
  const {
    register,
    handleSubmit,
    formState: { errors }
  }
    = useForm<CategoryInput>({
      mode: 'onTouched'
    });

  let history = useHistory();

  const onSubmit: SubmitHandler<CategoryInput> = (data: CategoryInput) => {
    (async () => {
      await service.createCategory(data);
      history.push("/category");
    })();
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <label htmlFor="NameCtrl">Name</label>
        <input {...register("name", { required: true, pattern: /^[a-zA-z ]+$/i })} type="text" className="form-control" placeholder="Enter category name..."></input>
        {errors.name?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
        {errors.name?.type === "pattern" && <p style={{ color: 'red' }}>Only alphabet character included!</p>}
      </div>
      <button type="submit" className="btn btn-primary">Add</button>
    </form>
  );
}
