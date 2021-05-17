import { Button, Form, Input, Select } from "antd";
import { useForm } from "antd/lib/form/Form";
import TextArea from "antd/lib/input/TextArea";
import Title from "antd/lib/typography/Title";
import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { BookService } from "../../../services/BookService";
import { CategoryService } from "../../../services/CategoryService";
import { BookInput } from "../../../models/book";
import { Category } from "../../../models/category";

const { Option } = Select;

export function UpdateBook() {

  const layout = {
    labelCol: {
      span: 16,
      offset: 3,
      pull: 9
    },
    wrapperCol: {
      span: 16,
      pull: 9
    },
  };
  const tailLayout = {
    wrapperCol: {
    },
  };

  const [categories, setCategory] = useState<Category[]>([]);
  const { bookId } = useParams<any>();
  const [form] = useForm();
  let cateService = new CategoryService();
  let bookService = new BookService();
  let history = useHistory();

  const onFinish = (data: BookInput) => {
    (async () => {
      await bookService.updateBook(data, bookId);
      history.push(`/book/details/${bookId}`);
    })();
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log('Failed:', errorInfo);
  };

  useEffect(() => {
    (async () => {
      let categories = await cateService.getAll();
      setCategory(categories);
    })();
  }, []);

  useEffect(() => {
    (async () => {
      let book = await bookService.getBook(bookId);
      form.setFieldsValue({
        title: book.title,
        shortContent: book.shortContent,
        url: book.url,
        categoryId: book.category.id
      });
    })();
  }, []);

  useEffect(() => {
    (async () => {
      let categories = await cateService.getAll();
      setCategory(categories);
    })();
  }, []);
  return (
    <>
      <Title>Update Book</Title>
      <Form
        {...layout}
        form={form}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        <Form.Item
          label="Title"
          name="title"
          rules={[
            {
              required: true,
              message: 'Please input book name!',
            }
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Short Content"
          name="shortContent"
          rules={[
            {
              required: true,
              message: 'Please input short content!',
            }
          ]}
        >
          <TextArea rows={14} />
        </Form.Item>

        <Form.Item
          label="Url"
          name="url"
          rules={[
            {
              required: true,
              message: 'Please input image link!',
            }
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Category"
          name="categoryId"
          rules={[
            {
              required: true,
              message: 'Please select a category!',
            }
          ]}>
          <Select
            style={{ width: 200 }}
          >
            {
              categories &&
              categories.length > 0 &&
              categories.map((category: Category) =>
              (
                <Option key={category.id} value={category.id}>{category.name}</Option>
              ))
            }
          </Select>
        </Form.Item>

        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit">
            Update
          </Button>
        </Form.Item>
      </Form>
    </>
  );
}
