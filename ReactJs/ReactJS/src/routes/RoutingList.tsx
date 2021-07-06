import React from 'react';
import { Route } from 'react-router-dom';
import { Home } from '../pages/home/Home';
import { LoginForm } from '../pages/login/Login';
import { ListPost } from '../pages/post/List';
import { Profile } from '../pages/profile/Profile';

const routes = [
  {
    path: '/',
    component: Home,
    key: '/',
  },
  {
    path: '/posts',
    component: ListPost,
    key: '/posts',
  },
  {
    path: '/login',
    component: LoginForm,
    key: '/login',
  },
  {
    path: '/profile',
    component: Profile,
    key: '/profile',
  },
];

export function RoutingList(): JSX.Element {
  return <>
    {
      routes.map(item => {
        if (item.path.split('/').length === 2) {
          return (
            <Route
              exact
              path={item.path}
              component={item.component}
              key={item.key}
            />
          );
        }
        return <Route path={item.path} component={item.component} key={item.key} />;
      })
    }
  </>
}
