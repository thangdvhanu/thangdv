import React from 'react';
import './App.css';
import {RatingBar} from './components/rating-bar'
import {Notification} from './components/checkbox'

function App() {
  const numberList = [1,2,3,4,5,6,7,8,9,10];
  const notiList = ["Email Notification", "Push Notification", "Monthly Reports", "Quarter Reports"];
  return (
    <div className="App">
      <RatingBar RatingNumbers={numberList}></RatingBar>
      <br></br>
      <Notification Notifications={notiList}></Notification>
    </div>
  );
}

export default App;
