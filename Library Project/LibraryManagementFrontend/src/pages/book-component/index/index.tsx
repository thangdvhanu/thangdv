import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { BookService } from '../../../services/BookService';
import "../style.css"
import { Book } from '../../../types/book';

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
    <div>
      <Link to={`/create/book`}>create</Link>
      <div className="row " >
        {books &&
          books.length > 0 &&
          books.map((book: Book) => (
            <div className="col-md-4 book " key={book.id}>
              <div>
                <img className="imgBook" src={book.url} alt="Book" />
                <div className="infoBook">
                  <h5 > {book.title}</h5>
                  <Link className="btn btn-success" to={`/details/book/${book.id}`}>Detail</Link>
                  <button className="btn btn-danger" onClick={() => { OnDelete(book.id) }}>Delete</button>
                </div>
              </div>
            </div>
          ))}
      </div>
    </div >
  );
}
