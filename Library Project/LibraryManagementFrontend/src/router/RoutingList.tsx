import React from 'react';
import { Route } from 'react-router-dom';
import { CreateBook } from '../pages/book-component/create/create';
import { BookDetail } from '../pages/book-component/details';
import { BookList } from '../pages/book-component/index';
import { UpdateBook } from '../pages/book-component/update/update';
import { CreateCategory } from '../pages/category-component/create/create';
import { CategoryList } from '../pages/category-component/index';
import { UpdateCategory } from '../pages/category-component/update/update';
import { AccessDenied } from '../pages/error-component/AccessDenied';
import { NotFound } from '../pages/error-component/NotFound';
import { Login } from '../pages/login-component/login';
import { Register } from '../pages/register-component/register';
import { CreateRequest } from '../pages/request-component/create/create';
import { RequestDetails } from '../pages/request-component/details/details';
import { RequestList } from '../pages/request-component/index';

const routes = [
  {
    path: '/400-not-found',
    component: NotFound,
    key: '/400-not-found',
  },
  {
    path: '/401-access-denied',
    component: AccessDenied,
    key: '/401-access-denied',
  },
  {
    path: '/login',
    component: Login,
    key: '/login',
  },
  {
    path: '/register',
    component: Register,
    key: '/register',
  },
  {
    path: '/home',
    component: Login,
    key: '/home',
  },
  {
    path: '/category',
    component: CategoryList,
    key: '/category',
  },
  {
    path: '/category/create',
    component: CreateCategory,
    key: '/category/create',
  },
  {
    path: '/category/update/:categoryId',
    component: UpdateCategory,
    key: '/update/category/:categoryId',
  },
  {
    path: '/book',
    component: BookList,
    key: '/book',
  },
  {
    path: '/book/details/:bookId',
    component: BookDetail,
    key: '/book/details/:bookId',
  },
  {
    path: '/book/create',
    component: CreateBook,
    key: '/book/create',
  },
  {
    path: '/book/update/:bookId',
    component: UpdateBook,
    key: '/book/update/:bookId',
  },
  {
    path: '/request',
    component: RequestList,
    key: '/request',
  },
  {
    path: '/request/create',
    component: CreateRequest,
    key: '/request/create',
  },
  {
    path: '/request/details/:requestId',
    component: RequestDetails,
    key: '/request/details/:requestId',
  },
  {
    path: '/request/approve/:requestId',
    key: '/request/approve/:requestId',
  },
  {
    path: '/request/reject/:requestId',
    key: '/request/reject/:requestId',
  }
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
