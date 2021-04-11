import React from "react";
import { Link } from "react-router-dom";

interface IProduct {
  id: number,
  name: string,
  description: string,
  price: number,
}

type ProductList = {
  Products: IProduct[]
}

export function ListProduct(props: ProductList) {
  const { Products } = props;
  return (
    <div>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Price</th>
          </tr>
        </thead>
        {Products && Products.map((product: IProduct) => (
          <tbody key={product.id}>
            <Link to={`/products/details/` + product.id}>
              <th scope="row">{product.id}</th>
            </Link>
            <td>{product.name}</td>
            <td>{product.description}</td>
            <td>{product.price}</td>
          </tbody>
        ))}
      </table>
    </div >
  );
}
