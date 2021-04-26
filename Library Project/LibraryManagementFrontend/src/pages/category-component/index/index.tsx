import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { CategoryService } from '../../../services/CategoryService';
import { Category } from '../../../types/category';
export function CategoryList() {
  const [categories, setListCategory] = useState<Category[]>([]);
  let i: number = 1;
  let service = new CategoryService();
  const [update, setUpdate] = useState(false);
  let OnDelete = (id: number) => {
    (async () => {
      await service.deleteCategory(id);
      setUpdate(pre => !pre);
    })();
  }

  useEffect(() => {
    (async () => {
      let listCategory = await service.getCategories();
      setListCategory(listCategory);
    })();
  }, [update]);
  return (
    <div>
      <Link to={`/create/category`}>create</Link>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Name</th>
            <th scope="col">Action</th>
          </tr>
        </thead>
        {categories && categories.map((category: Category) => (
          <tbody key={i}>
            <tr>
              <th>{i++}</th>
              <th>{category.name}</th>
              <th>
                <Link to={`/update/category/` + category.id}><button>Edit</button></Link>
                <span></span>
                <button onClick={() => { OnDelete(category.id) }}>Delelet</button>
              </th>
            </tr>
          </tbody>
        ))}
      </table>
    </div >
  );
}
