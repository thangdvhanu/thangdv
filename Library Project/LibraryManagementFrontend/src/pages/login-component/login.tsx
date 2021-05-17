import { Button, Form, Input } from "antd";
import Title from "antd/lib/typography/Title";
import React from "react";
import { useHistory } from "react-router-dom";
import { AuthenticationSerivce } from "../../services/AuthenticationSerivce";
import { UserLogin } from "../../models/user";

export function Login() {
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

  let history = useHistory();
  const service = new AuthenticationSerivce();

  const onFinish = (data: UserLogin) => {
    console.log('Success:', data);
    (async () => {
      let userLogin = await service.login(data);
      sessionStorage.setItem("id", userLogin.id.toString());
      sessionStorage.setItem("role", userLogin.role.name);
      sessionStorage.setItem("username", userLogin.username);
      history.push("/category");
    })();
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log('Failed:', errorInfo);
  };

  return (
    <>
      <Title>Login</Title>
      <Form
        {...layout}
        name="basic"
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        <Form.Item
          label="Username"
          name="username"
          rules={[
            {
              required: true,
              message: 'Please input your username!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Password"
          name="password"
          rules={[
            {
              required: true,
              message: 'Please input your password!',
            },
          ]}
        >
          <Input.Password />
        </Form.Item>

        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit">
            Login
      </Button>
        </Form.Item>
      </Form>
    </>
  );
}
