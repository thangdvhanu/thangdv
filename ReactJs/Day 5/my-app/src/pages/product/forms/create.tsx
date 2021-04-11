import axios from 'axios';
import { SubmitHandler, useForm } from 'react-hook-form';

interface IProduct {
  id?: number,
  name: string,
  description: string,
  price: number,
}

export function CreateForm() {
  const {
    register,
    handleSubmit,
    formState: { errors }
  }
    = useForm<IProduct>({
      mode: 'onTouched'
    });
  const onSubmit: SubmitHandler<IProduct> = (data: IProduct) => {
    axios.post("http://localhost:5000/products", data)
      .then(
        (res) => {
          if (!(res.status === 201)) {
            alert("Add product failed!")
          }
        }
      );
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <label htmlFor="NameCtrl">Name</label>
        <input {...register("name", { required: true })} type="text" className="form-control" placeholder="Enter product name..."></input>
        {errors.name?.type === "required" && <p style={{ color: 'red' }}>Name is required!</p>}
      </div>
      <div className="form-group">
        <label htmlFor="DescriptionCtrl">Description</label>
        <input {...register("description")} type="text" className="form-control" placeholder="Enter description..."></input>
      </div>
      <div className="form-group">
        <label htmlFor="PriceCtrl">Price</label>
        <input {...register("price", { required: true, pattern: /^[0-9,.]+$/i })} type="text" className="form-control" placeholder="Enter price..."></input>
        {errors.price?.type === "required" && <p style={{ color: 'red' }}>Price is required!</p>}
        {errors.price?.type === "pattern" && <p style={{ color: 'red' }}>Only number included!</p>}
      </div>
      <button type="submit" className="btn btn-primary">Add</button>
    </form>
  );
}
