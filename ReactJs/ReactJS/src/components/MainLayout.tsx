import { Layout } from 'antd';
import React from 'react';
import { RoutingList } from '../routes/RoutingList';
import { NavBar } from './NavBar';
const { Content } = Layout;
import './style.css';

function MainLayout() {
  return (
    <Layout>
      <NavBar />
      <Content className="site-layout">
        <div className="routing-list">
          <RoutingList />
        </div>
      </Content>
    </Layout>
  );
}

export default MainLayout;
