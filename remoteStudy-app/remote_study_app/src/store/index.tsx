import { combineReducers, compose, createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import authReducer from "./auth/authReducer";
const reducers = combineReducers({
  authState: authReducer
});

const store = createStore(reducers, compose(applyMiddleware(thunk)));

export default store;
