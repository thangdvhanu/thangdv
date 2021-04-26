import { SubmitHandler, useForm } from "react-hook-form";
import { useHistory } from "react-router-dom";
import { AuthenticationSerivce } from "../../services/AuthenticationSerivce";
import { UserLogin } from "../../types/user";

export function Login() {
  const {
    register,
    handleSubmit,
    formState: { errors }
  }
    = useForm<UserLogin>({
      mode: 'onTouched'
    });
  let history = useHistory();
  const service = new AuthenticationSerivce();

  const onSubmit: SubmitHandler<UserLogin> = (data: UserLogin) => {
    (async () => {
      let userLogin = await service.login(data);
      sessionStorage.setItem("id", userLogin.id.toString());
      sessionStorage.setItem("role", userLogin.role.name);
      sessionStorage.setItem("username", userLogin.username);
      history.push("/home");
    })();
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <label htmlFor="UsernameCtrl">Username</label>
        <input {...register("username", { required: true })} type="text" className="form-control" placeholder="Enter username..."></input>
        {errors.username?.type === "required" && <p style={{ color: 'red' }}>Username is required!</p>}
        <label htmlFor="PasswordCtrl">Password</label>
        <input {...register("password", { required: true })} type="password" className="form-control" placeholder="Enter password..."></input>
        {errors.password?.type === "required" && <p style={{ color: 'red' }}>Password is required!</p>}
      </div>
      <button type="submit" className="btn btn-primary">Login</button>
    </form>
  );
}
