import React from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Router, Switch } from 'react-router-dom';
import history from './routes/History';
import MainLayout from './components/MainLayout';

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
