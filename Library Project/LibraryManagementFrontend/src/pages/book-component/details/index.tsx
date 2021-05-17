import { ArrowLeftOutlined, DeleteOutlined, EditOutlined, ZoomInOutlined } from '@ant-design/icons';
import { Button, Image, Popconfirm, Space } from 'antd';
import Title from 'antd/lib/typography/Title';
import React, { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router';
import { Link } from 'react-router-dom';
import { BookService } from '../../../services/BookService';
import { Book } from '../../../models/book';

export function BookDetail() {
  const [book, setBook] = useState<Book>();
  let { bookId } = useParams<any>();
  let service = new BookService();
  let history = useHistory();
  let OnDelete = (id: number) => {
    (async () => {
      await service.deleteBook(id);
      history.push('/book');
    })();
  }
  useEffect(() => {
    (async () => {
      let book = await service.getBook(bookId);
      setBook(book);
    })();
  }, []);

  return (
    <div>
      <Image style={{ display: 'inline-block' }}
        className="col-6"
        width={500}
        src={book?.url}
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
      <div style={{ display: 'inline-block' }}>
        <Title>{`Title: ${book?.title}`}</Title>
        <h4>{`Genre: ${book?.category.name}`}</h4>
        <h5>{`Description: ${book?.shortContent}`}</h5>
        <Space size="middle">
          <Button icon={<ArrowLeftOutlined />} size='middle'>
            <Link style={{ color: 'black' }} to={`/book`}>Return</Link>
          </Button>
          <Button icon={<EditOutlined />} size='middle'>
            <Link style={{ color: 'black' }} to={`/book/update/${bookId}`}>Edit</Link>
          </Button>
          <Popconfirm title="Delete?" onConfirm={() => { OnDelete(bookId) }}>
            <Button icon={<DeleteOutlined />} size='middle'>
              Delete
            </Button>
          </Popconfirm>
        </Space>
      </div>
    </div>
    // <div className="container">
    //   {book &&
    //     <div className="row">
    //       <div className="col-4">
    //         <img className="imgDetail" src={book.url} alt="" /></div>
    //       <div className="col-6 ">
    //         <h3> {book.title} </h3>
    //         <h4> {book.shortContent} </h4>
    //         <div>{book.category.name}</div>
    //         <Link className="btn btn-success" to={`/update/book/${book.id}`}>Edit</Link>
    //         <Link className="btn btn-primary" to={`/book`}>Return</Link>
    //       </div>
    //     </div>
    //   }
    // </div>
  );
}
