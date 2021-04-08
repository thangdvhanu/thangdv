import React from 'react';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from 'react-router-dom';
import { LoginFormComponent } from './pages/login-component/login';
import { RegisterFormComponent } from './pages/register-component/register';
import { ProductFormComponent } from './pages/product-components/product-form';

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
                    <Link to="/login" className="nav-link active" aria-current="page">Login</Link>
                  </li>
                  <li className="nav-item">
                    <Link className="nav-link active" to="/Register">Register</Link>
                  </li>
                  <li className="nav-item">
                    <Link className="nav-link active" to="/add-product">Add Product</Link>
                  </li>
                </ul>
              </div>
            </div>
          </nav>

          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
          <Switch>
            <Route path="/login">
              <LoginFormComponent />
            </Route>
            <Route path="/register">
              <RegisterFormComponent />
            </Route>
            <Route path="/add-product">
              <ProductFormComponent />
            </Route>
          </Switch>
        </div>
      </Router>
    </div>
  );
}

export default App;
