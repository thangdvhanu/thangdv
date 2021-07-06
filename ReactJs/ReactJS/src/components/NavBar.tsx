import { Menu } from "antd";
import { Header } from "antd/lib/layout/layout";
import { Link } from "react-router-dom";
import './style.css';

export function NavBar() {
  return (
    <Header className="navbar-header">
      <Menu className="navbar-menu" theme="light" mode="horizontal">
        <Menu.Item key="/">
          <Link to="/">Home</Link>
        </Menu.Item>
        <Menu.Item key="/posts">
          <Link to="/posts">Posts</Link>
        </Menu.Item>
        <Menu.Item key="/profile">
          <Link to="/profile">Profile</Link>
        </Menu.Item>
        {!localStorage.getItem("token") && 
        <Menu.Item key="/login">
          <Link to="/login">Login</Link>
        </Menu.Item>}
        {localStorage.getItem("token") && 
        <Menu.Item key="/logout">
          <Link to="/logout">Logout</Link>
        </Menu.Item>}
      </Menu>
    </Header>
  );
}
