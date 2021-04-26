import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { Link } from 'react-router-dom';
import { BookService } from '../../../services/BookService';
import { Book } from '../../../types/book';

export function BookDetail() {
  const [book, setBook] = useState<Book>();
  let { bookId } = useParams<any>();
  let service = new BookService();
  useEffect(() => {
    (async () => {
      let book = await service.getBook(bookId);
      setBook(book);
    })();
  }, []);

  return (
    <div className="container">
      {book &&
        <div className="row">
          <div className="col-4">
            <img className="imgDetail" src={book.url} alt="" /></div>
          <div className="col-6 ">
            <h3> {book.title} </h3>
            <h4> {book.shortContent} </h4>
            <div>{book.category.name}</div>
            <Link className="btn btn-success" to={`/update/book/${book.id}`}>Edit</Link>
            <Link className="btn btn-primary" to={`/book`}>Return</Link>
          </div>
        </div>
      }
    </div>
  );
}
