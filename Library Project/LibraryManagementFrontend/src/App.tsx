import './App.css';
import {
  Router,
  Switch} from 'react-router-dom';
import React from 'react';
import 'antd/dist/antd.css';
import history from './router/history';
import MainLayout from './component/main-layout/MainLayout';

function App() {
  return (
    <div className="App">
        <Router history={history}>
          <div>
            <Switch>
              <MainLayout />
            </Switch>
          </div>
        </Router>
    </div>
  );
}

export default App;
