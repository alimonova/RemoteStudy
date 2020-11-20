import { combineReducers, compose, createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";

import courseList from "../modules/courseList/reducer";

const reducers = combineReducers({ courseList });

const store = createStore(reducers, compose(applyMiddleware(thunk)));

export default store;
