import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { BookService } from '../../../services/BookService';
import "../style.css"
import { Book } from '../../../models/book';
import { Button, Space, Table, Image, Popconfirm } from 'antd';
import { DeleteOutlined, EditOutlined, SnippetsOutlined, ZoomInOutlined } from '@ant-design/icons';

const { Column } = Table;

export function BookList() {
  const [books, setBook] = useState<Book[]>([]);
  let service = new BookService();
  const [update, setUpdate] = useState(false);
  let OnDelete = (id: number) => {
    (async () => {
      await service.deleteBook(id);
      setUpdate(pre => !pre);
    })();
  }
  useEffect(() => {
    (async () => {
      let books = await service.getBooks();
      setBook(books);
    })();
  }, [update]);
  return (
    <>
      {books && books.length > 0 &&
        <Table key="table" dataSource={books} pagination={{ defaultPageSize: 7 }}>
          <Column
            align='center'
            title="Book"
            dataIndex="url"
            key="url"
            render={(url) => (
              <Image
                width={100}
                src={url}
                preview={{
                  maskClassName: 'customize-mask',
                  mask: (
                    <Space direction="vertical" align="center">
                      <ZoomInOutlined />
                      Zoom
                    </Space>
                  ),
                }}
              />
            )}
          />
          <Column align='center' title="Title" dataIndex="title" key="title" />
          <Column align='center' title="Short Content" dataIndex="shortContent" key="shortContent" />
          <Column
            align='center'
            title="Action"
            dataIndex='id'
            key="action"
            render={(id) => (
              <Space size="middle">
                <Button icon={<SnippetsOutlined />} size='middle'>
                  <Link style={{ color: 'black' }} to={`/book/details/${id}`}>Detail</Link>
                </Button>
                <Button icon={<EditOutlined />} size='middle'>
                  <Link style={{ color: 'black' }} to={`/book/update/${id}`}>Edit</Link>
                </Button>
                <Popconfirm title="Delete?" onConfirm={() => { OnDelete(id) }}>
                  <Button icon={<DeleteOutlined />} size='middle'>
                    Delete
                  </Button>
                </Popconfirm>
              </Space>
            )}
          />
        </Table>
      }
    </>
  );
}
