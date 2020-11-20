import { status } from "../../utils/config";
import types from "./types";

const courses = {
  courseList: [],
  courseListStatus: status[0],
};

export default (state = courses, action) => {
  const { payload, type } = action;
  if (typeof state === undefined) {
    return communication;
  }

  switch (type) {
    case types.LOAD_COURSES:
      return {
        ...state,
        courseList: [],
        courseListStatus: status[2],
      };

    case types.SUCCESSFUL_LOADED_COURSES:
      if (typeof payload === "object") {
        return {
          ...state,
          courseList: payload,
          courseListStatus: status[1],
        };
      } else return state;

    case types.ERROR_LOADED_COURSES:
      return {
        ...state,
        courseList: [],
        courseListStatus: status[3],
      };
  }
};
