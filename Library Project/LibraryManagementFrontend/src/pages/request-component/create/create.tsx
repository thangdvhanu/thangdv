import { SnippetsOutlined, ZoomInOutlined } from "@ant-design/icons";
import { Button, Checkbox, Image, message, Space, Table } from "antd";
import Column from "antd/lib/table/Column";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { BookService } from "../../../services/BookService";
import { RequestService } from "../../../services/RequestService";
import { Book } from "../../../models/book";

export function CreateRequest() {
  const [books, setBook] = useState<Book[]>([]);
  let userId = JSON.parse(sessionStorage.getItem("id")!);
  let bookIds: number[] = [];
  let history = useHistory();
  const bookService = new BookService();
  const requestService = new RequestService();
  let OnChange = (id: number) => {
    let index = bookIds.indexOf(id);
    if (bookIds.length > 4) {
      message.info("You can borrow maximum 5 books!");
    }
    else {
      if (!(index < 0)) {
        bookIds.splice(index, 1);
        console.log(bookIds);
      }
      else {
        bookIds.push(id);
        console.log(bookIds);
      }
    }
  };
  let OnRequest = () => {
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
    <>
      <Button icon={<SnippetsOutlined />} onClick={() => OnRequest()} size='middle'>
        Make Borrow Request
      </Button>
      {books && books.length > 0 &&
        <Table key="table" dataSource={books} pagination={{ defaultPageSize: 7 }}>
          <Column render={(text, record: any, index) => (
            <Checkbox onChange={() => OnChange(record.id)}></Checkbox>
          )} />
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
        </Table>
      }
    </>
  );
}
