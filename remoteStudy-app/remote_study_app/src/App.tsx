import React from "react";
import "./App.scss";

import Sidebar from "./components/Sidebar";
import CourseListPage from "./containers/CourseListPage"

function App() {
  return (
    <>
      <div className="nebody">
        <h1>Remote Study</h1>
        <CourseListPage />
      </div>
    </>
  );
}

export default App;
