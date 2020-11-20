import types from "../types";

export default () => async (dispatch) => {
  dispatch({
    type: types.LOAD_COURSES,
  });
  return loadCourses().then((res) => {
    if (!res.err) {
      dispatch({
        type: types.SUCCESSFUL_LOAD_COURSES,
        payload: res,
      });
    } else {
      dispatch({
        type: types.ERROR_LOAD_COURSES,
      });
      console.log(res.err);
    }
  });
};

const loadCourses = () => {
  return new Promise((resolve) => {
    resolve(coursesList);
  });
};

const coursesList = [{ id: 1, title: "IOS course" }];
