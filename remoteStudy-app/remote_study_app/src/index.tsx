import React from "react";
import ReactDOM from "react-dom";
// import { Provider } from "react-redux";
// import store from "./store";
import App from "./App";
import { BrowserRouter } from "react-router-dom";

const app = (
    <BrowserRouter>
      <App />
    </BrowserRouter>
);
ReactDOM.render(app, document.getElementById("root"));
