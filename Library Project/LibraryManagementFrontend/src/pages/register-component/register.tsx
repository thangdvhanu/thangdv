import React from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useHistory } from "react-router-dom";
import { UserService } from "../../services/UserService";
import { UserOnRegister } from "../../types/user";

export function Register() {
  const {
    register,
    handleSubmit,
    formState: { errors }
  }
    = useForm<UserOnRegister>({
      mode: 'onTouched'
    });
    let history = useHistory();
    const service = new UserService();

  const onSubmit: SubmitHandler<UserOnRegister> = (data: UserOnRegister) => {
    if(data.password===data.passwordConfirm){
      service.register(data);
      history.push("/login");
    }
        else{
          alert("Password and Password Confirmation are not match!")
        }
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <h2>Create account</h2>
        <label htmlFor="UsernameCtrl">Username</label>
        <input {...register("username", { required: true })} type="text" className="form-control" placeholder="Enter username..."></input>
        {errors.username?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
        <label htmlFor="PasswordCtrl">Password</label>
        <input {...register("password", { required: true })} type="password" className="form-control" placeholder="Enter password..."></input>
        {errors.password?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
        <label htmlFor="PasswordConfirmCtrl">Password Confirmation</label>
        <input {...register("passwordConfirm", { required: true })} type="password" className="form-control" placeholder="Enter password..."></input>
        {errors.passwordConfirm?.type === "required" && <p style={{ color: 'red' }}>This field is required!</p>}
      </div>
      <button type="submit" className="btn btn-primary">Register</button>
    </form>
  );
}
