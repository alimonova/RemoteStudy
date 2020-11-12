import React from "react";
import "./App.scss";

import Sidebar from "./components/Sidebar";

function App() {
  return (
    <>
      <Sidebar />
      <div className="nebody">
        <h1>Remote Study</h1>
      </div>
    </>
  );
}

export default App;
