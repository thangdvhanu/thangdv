import { Button, Form, Input, Select } from "antd";
import TextArea from "antd/lib/input/TextArea";
import Title from "antd/lib/typography/Title";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { BookService } from "../../../services/BookService";
import { CategoryService } from "../../../services/CategoryService";
import { BookInput } from "../../../models/book";
import { Category } from "../../../models/category";

const { Option } = Select;

export function CreateBook() {

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
  let cateService = new CategoryService();
  let bookService = new BookService();

  let history = useHistory();

  const onFinish = (data: BookInput) => {
    console.log('Success:', data);
    (async () => {
      await bookService.createBook(data);
      history.push("/book");
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
  return (
    <>
      <Title>Create Book</Title>
      <Form
        {...layout}
        name="basic"
        initialValues={{
          remember: true,
        }}
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
            showSearch
            style={{ width: 200 }}
            placeholder="Select a category"
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
            Create
          </Button>
        </Form.Item>
      </Form>
    </>
  );
}
