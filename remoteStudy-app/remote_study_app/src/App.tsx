import React from "react";
import Sidebar from "./components/Sidebar";
import CourseListPage from "./containers/CourseListPage";
import {Switch, Route,Redirect} from 'react-router-dom';
import LoginForm from "./containers/Auth/Login";
import SignUpForm from "./containers/Auth/SignUp";
import './styles/main.scss';

function App() {
  return (
    <>
      <Switch>
        <Route path="/login" component ={LoginForm}></Route>
        <Route path="/signup" component ={SignUpForm}></Route>
        <Route path="/courses" component ={CourseListPage}></Route>

        <Redirect from="/" to="/courses"  exact/>

      </Switch>
    </>
  );
}

export default App;
