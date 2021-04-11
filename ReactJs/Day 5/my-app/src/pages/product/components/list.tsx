import React, { useEffect, useState } from 'react';
import { ListProduct } from '../forms/list';
import { GetProducts } from '../services/product-service';

export function ProductList() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState(null);
  const service = GetProducts();
  useEffect(() => {
    (async () => {
      service
        .then((res) => res.data)
        .then((data) => {
          setProducts(data);
        })
        .catch((err) => setError(err));
    }
    )();
  }, [service]);
  return (
    <div>
      <ListProduct Products={products}></ListProduct>
      {error && <p style={{ color: 'red' }}>Something is wrong!</p>}
    </div>
  );
}
