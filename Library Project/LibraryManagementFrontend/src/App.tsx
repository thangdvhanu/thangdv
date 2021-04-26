import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from 'react-router-dom';
import React from 'react';
import { Login } from './pages/login-component/login';
import { Register } from './pages/register-component/register';
import { CreateBook } from './pages/book-component/create/create';
import { BookList } from './pages/book-component/index';
import { BookDetail } from './pages/book-component/details';
import { UpdateBook } from './pages/book-component/update/update';
import { RequestList } from './pages/request-component/index/index';
import { CreateRequest } from './pages/request-component/create/create';
import { Home } from './pages/home-component/home';
import axios from 'axios';
import { RequestDetails } from './pages/request-component/details/details';
import { CategoryList } from './pages/category-component/index';
import { CreateCategory } from './pages/category-component/create/create';
import { UpdateCategory } from './pages/category-component/update/update';

function App() {
  return (
    <div className="App">
      <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
              <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                  {sessionStorage.getItem("username") === null &&
                    <>
                      <li className="nav-item">
                        <Link to="/register" className="nav-link active" aria-current="page">Register</Link>
                      </li>
                      <li className="nav-item">
                        <Link to="/login" className="nav-link active" aria-current="page">Login</Link>
                      </li>
                    </>
                  }
                </ul>
              </div>
            </div>
          </nav>

          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
          <Switch>
            <Route path="/login">
              <Login></Login>
            </Route>
            <Route path="/register">
              <Register></Register>
            </Route>
            <Route path="/home">
              <Home></Home>
            </Route>
            <Route path="/category">
              <CategoryList></CategoryList>
            </Route>
            <Route path="/create/category">
              <CreateCategory></CreateCategory>
            </Route>
            <Route path="/update/category/:categoryId">
              <UpdateCategory></UpdateCategory>
            </Route>
            <Route path="/book">
              <BookList></BookList>
            </Route>
            <Route path="/details/book/:bookId">
              <BookDetail></BookDetail>
            </Route>
            <Route path="/create/book">
              <CreateBook></CreateBook>
            </Route>
            <Route path="/update/book/:bookId">
              <UpdateBook></UpdateBook>
            </Route>
            <Route path="/request">
              <RequestList></RequestList>
            </Route>
            <Route path="/create/request">
              <CreateRequest></CreateRequest>
            </Route>
            <Route path="/details/request/:requestId">
              <RequestDetails></RequestDetails>
            </Route>
            <Route path="/approve/request/:requestId">
            </Route>
            <Route path="/reject/request/:requestId">
            </Route>
            <Route path="/logout">
              {/* <Logout></Logout> */}
            </Route>
          </Switch>
        </div>
      </Router>
    </div>
  );
}

export default App;
