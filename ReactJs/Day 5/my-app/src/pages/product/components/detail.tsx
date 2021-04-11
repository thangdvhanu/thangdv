import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { ProductDetails } from "../forms/detail";
import { GetProductById } from "../services/product-service";

export function Details() {
  const [product, setProduct] = useState([]);
  const [error, setError] = useState(null);
  const { productId } = useParams<any>();
  const service = GetProductById(productId);
  service
    .then((res) => setProduct(res.data))
    .catch((err) => setError(err))
  return (
    <div>
      {/* <ProductDetails ProductInfo={product}></ProductDetails> */}
    </div>
  );
}
