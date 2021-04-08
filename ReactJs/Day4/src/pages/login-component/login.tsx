import React from 'react';
import { SubmitHandler, useForm } from 'react-hook-form';
import '../../shared/css/form.css';

type Inputs = {
  Username: string;
  Password: string;
};

export function LoginFormComponent() {
  const {
    register,
    handleSubmit,
    formState: { errors }
  } = useForm<Inputs>();

  const onSubmit: SubmitHandler<Inputs> = (data) => {
    alert(JSON.stringify(data));
  };


  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <label>Username</label>
      <input {...register("Username", { required: true })} placeholder="Username" />
      {errors?.Username?.type === "required" && <p style={{ color: 'red' }}>Username is required!</p>}
      <label>Password</label>
      <input
        {...register("Password", { required: true })} placeholder="Password"
      />
      {errors?.Password?.type === "required" && <p style={{ color: 'red' }}>Password is required</p>}
      <button type="submit">Login</button>
    </form>
  );
}
export default LoginFormComponent;
