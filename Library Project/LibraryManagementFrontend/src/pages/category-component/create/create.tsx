import { Button, Form, Input } from "antd";
import Title from "antd/lib/typography/Title";
import React from "react";
import { useHistory } from "react-router-dom";
import { CategoryService } from "../../../services/CategoryService";
import { CategoryInput } from "../../../models/category";

export function CreateCategory() {
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

  let service = new CategoryService();

  let history = useHistory();

  const onFinish = (data: CategoryInput) => {
    console.log('Success:', data);
    (async () => {
      await service.createCategory(data);
      history.push("/category");
    })();
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log('Failed:', errorInfo);
  };

  return (
    <>
      <Title>Create Category</Title>
      <Form
        {...layout}
        name="basic"
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        <Form.Item
          label="Name"
          name="name"
          rules={[
            {
              required: true,
              message: 'Please input category name!',
            },
            {
              pattern: /^[A-Za-z ]+$/i,
              message: 'Please input alphabet character!'
            }
          ]}
        >
          <Input />
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
