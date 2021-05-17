import { Button, Form, Input } from "antd";
import { useForm } from "antd/lib/form/Form";
import Title from "antd/lib/typography/Title";
import React, { useEffect } from "react";
import { useHistory, useParams } from "react-router-dom";
import { CategoryService } from "../../../services/CategoryService";
import { CategoryInput } from "../../../models/category";

export function UpdateCategory() {
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

  const { categoryId } = useParams<any>();

  let service = new CategoryService();

  let history = useHistory();

  const onFinish = (data: CategoryInput) => {
    console.log('Success:', data);
    (async () => {
      await service.updateCategory(data, categoryId);
      history.push("/category");
    })();
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log('Failed:', errorInfo);
  };

  const [form] = useForm();

  useEffect(() => {
    (async () => {
      let category = await service.getCategory(categoryId);
      form.setFieldsValue({
        name: category.name,
      });
    })();
  }, []);

  return (
    <>
      <Title>Update Category</Title>
      <Form
        {...layout}
        form={form}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        <Form.Item
          name="name"
          label="Name"
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
            Update
          </Button>
        </Form.Item>
      </Form>
    </>
  );
}
