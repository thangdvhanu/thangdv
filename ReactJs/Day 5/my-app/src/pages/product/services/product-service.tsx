import axios from "axios";

export function GetProducts() {
  return axios.get("http://localhost:5000/products");
}
export function GetProductById(index: number) {
  return axios.get("http://localhost:5000/products/" + index);
}
