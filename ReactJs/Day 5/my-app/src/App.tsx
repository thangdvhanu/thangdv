import React from 'react';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from 'react-router-dom';
import { ProductList } from './pages/product/components/list';
import { CreateProduct } from './pages/product/components/create';
import { Details } from './pages/product/components/detail';

function App() {
  return (
    <div className="App">
      <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
              <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                  <li className="nav-item">
                    <Link to="/products/list" className="nav-link active" aria-current="page">Product List</Link>
                  </li>
                  <li className="nav-item">
                    <Link className="nav-link active" to="/products/create">Create Product</Link>
                  </li>
                </ul>
              </div>
            </div>
          </nav>

          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
          <Switch>
          <Route path="/products/list">
              <ProductList />
            </Route>
            <Route path="/products/details/:productId">
              <Details></Details>
            </Route>
            <Route path="/products/create">
              <CreateProduct />
            </Route>
          </Switch>
        </div>
      </Router>
    </div>
  );
}

export default App;
