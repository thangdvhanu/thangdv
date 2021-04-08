import React from 'react';
import { SubmitHandler, useForm } from 'react-hook-form';

type Inputs = {
  Code: string,
  Name: string,
  Price: string,
  Quantity: string
  Description: string
}
export function ProductFormComponent() {
  const {
    register,
    handleSubmit,
    formState: { errors }
  } = useForm<Inputs>();
  const onSubmit: SubmitHandler<Inputs> = (data) => { alert(JSON.stringify(data)); };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <label>Code</label>
      <input {...register("Code", { required: true, maxLength: 20, pattern: /^[0-9]+$/i })} placeholder="Product Code" />
      {errors?.Code?.type === "required" && <p style={{ color: 'red' }}>Product Code is required!</p>}
      {errors?.Code?.type === "maxLength" && <p>Product Code cannot exceed 20 characters!</p>}
      {errors?.Code?.type === "pattern" && <p style={{ color: 'red' }}>Product Code accepts numbers only!</p>}
      <label>Name</label>
      <input {...register("Name", { required: true, maxLength: 100 })} placeholder="Product Name" />
      {errors?.Name?.type === "required" && <p style={{ color: 'red' }}>Product Name is required!</p>}
      {errors?.Name?.type === "maxLength" && <p>Product Name cannot exceed 100 characters!</p>}
      <label>Price</label>
      <input {...register("Price", { required: true, pattern: /^[0-9,.]+$/i })} placeholder="Price" />
      {errors?.Price?.type === "required" && <p style={{ color: 'red' }}>Price is required!</p>}
      {errors?.Price?.type === "pattern" && <p style={{ color: 'red' }}>Price accepts numbers only!</p>}
      <label>Quantity</label>
      <input {...register("Quantity", { required: true, pattern: /^[0-9]+$/i })} placeholder="Quantity" />
      {errors?.Quantity?.type === "required" && <p style={{ color: 'red' }}>Quantity is required!</p>}
      {errors?.Quantity?.type === "pattern" && <p style={{ color: 'red' }}>Quantity accepts numbers only!</p>}
      <label>Description</label>
      <input {...register("Description")} placeholder="Description" />
      <button type="submit">Add</button>
    </form>
  );
}
