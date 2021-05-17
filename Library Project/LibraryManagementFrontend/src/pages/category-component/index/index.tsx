import { useEffect, useState } from 'react';
import useDataTable from '../../../component/DataTable';
import { CategoryService } from '../../../services/CategoryService';
import { Category } from '../../../models/category';

export function CategoryList() {
  let service = new CategoryService();

  const columns = [
    {
      title: 'Name',
      dataIndex: 'name',
      align: 'center',
      key: 'name',
    },
  ];

  const {
    DataTable,
  } = useDataTable<Category>({
    service: service,
    columns: columns,
    updateEntityPath: 'category/update',
  });

  return (
    <>
      <DataTable />
    </>
  );
}
