import React from 'react';
import { SubmitHandler, useForm } from 'react-hook-form';
import '../../shared/css/form.css';

type Inputs = {
  FirstName: string,
  LastName: string,
  Username: string,
  Password: string,
  PhoneNumber: string,
};

export function RegisterFormComponent() {
  const {
    register,
    handleSubmit,
    formState: { errors }
  }
    = useForm<Inputs>();
  const onSubmit: SubmitHandler<Inputs> = (data) => { alert(JSON.stringify(data)); };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <label>First Name</label>
      <input {...register("FirstName", { required: true, maxLength: 20, pattern: /^[A-Za-z]+$/i })} placeholder="First Name" />
      {errors?.FirstName?.type === "required" && <p style={{ color: 'red' }}>First Name is required!</p>}
      {errors?.FirstName?.type === "maxLength" && <p>First Name cannot exceed 20 characters!</p>}
      {errors?.FirstName?.type === "pattern" && <p style={{ color: 'red' }}>First Name accepts alphabet characters only!</p>}
      <label>Last Name</label>
      <input {...register("LastName", { required: true, maxLength: 15, pattern: /^[A-Za-z]+$/i })} placeholder="Last Name" />
      {errors?.LastName?.type === "required" && <p style={{ color: 'red' }}>Last Name is required!</p>}
      {errors?.LastName?.type === "maxLength" && <p style={{ color: 'red' }}>Last Nam cannot exceed 15 characters!</p>}
      {errors?.LastName?.type === "pattern" && <p style={{ color: 'red' }}>Last Name accepts alphabet characters only!</p>}
      <label>Username</label>
      <input {...register("Username", { required: true, maxLength: 15, pattern: /^[A-Za-z]+$/i })} placeholder="Username" />
      {errors?.Username?.type === "required" && <p style={{ color: 'red' }}>Username is required!</p>}
      {errors?.Username?.type === "maxLength" && <p style={{ color: 'red' }}>Username cannot exceed 15 characters!</p>}
      {errors?.Username?.type === "pattern" && <p style={{ color: 'red' }}>Username accepts alphabet characters only!</p>}
      <label>Password</label>
      <input {...register("Password", { required: true })} type="password" placeholder="Password" />
      {errors?.Password?.type === "required" && <p style={{ color: 'red' }}>Password is required!</p>}
      <label>Phone Number</label>
      <input {...register("PhoneNumber", { required: true, maxLength: 12, pattern: /^[0-9]+$/i })} placeholder="Phone Number" />
      {errors?.PhoneNumber?.type === "required" && <p style={{ color: 'red' }}>Phone Number is required!</p>}
      {errors?.PhoneNumber?.type === "maxLength" && <p style={{ color: 'red' }}>Phone Number cannot exceed 12 characters!</p>}
      {errors?.PhoneNumber?.type === "pattern" && <p style={{ color: 'red' }}>Phone Number accepts numbers only!</p>}
      <button type="submit">Register</button>
    </form>
  );
}
export default RegisterFormComponent;
