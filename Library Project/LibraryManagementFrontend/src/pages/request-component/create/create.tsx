import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { BookService } from "../../../services/BookService";
import { RequestService } from "../../../services/RequestService";
import { Book } from "../../../types/book";

export function CreateRequest() {
  const [books, setBook] = useState<Book[]>([]);
  let userId = JSON.parse(sessionStorage.getItem("id")!);
  let bookIds: number[] = [];
  let history = useHistory();
  const bookService = new BookService();
  const requestService = new RequestService();
  let onPicking = (id: number) => {
    if (bookIds.length > 4) {
      alert("You can borrow maximum 5 books!");
    }
    else {
      if (bookIds.includes(id)) {
        alert("You already picked this book!");
      }
      else {
        bookIds.push(id);
        console.log(bookIds);
      }
    }
  };
  let onRequest = () => {
    (async () => {
      requestService.createRequest(userId, bookIds);
      history.push("/request");
    })();
  };

  useEffect(() => {
    (async () => {
      let books = await bookService.getBooks();
      setBook(books);
    })();
  }, []);
  return (
    <div>
      <div className="row " >
        {books &&
          books.map((book: Book) => (
            <div className="col-md-4 book " key={book.id} onClick={() => { onPicking(book.id) }}>
              <div>
                <img className="imgBook" src={book.url} alt="Book" />
                <div >
                  <h5 > {book.title}</h5>
                </div>
              </div>
            </div>
          ))}
      </div>
      <button className="btn btn-primary" onClick={() => onRequest()}>Borrow</button>
    </div >
  );
}
