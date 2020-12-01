import React, { useCallback, useEffect } from "react";
import Container from "@material-ui/core/Container";
import { useDispatch } from "react-redux";
import { useShallowEqualSelector } from "../../utils/hooks";

import WithLayout from "../../hoc/WithLayout";
import { CourseCard } from "../../components/Cards";

interface ICourseListPageProps {}

const CourseListPage = () => {
  /** REDUX ACTIONS */
  // const dispatch = useDispatch();

  // const loadCoursesHandler = useCallback(() => {
  //   dispatch(coursesActions.loadCourses());
  // }, [dispatch]);

  // /** USE EFFECTS */
  // useEffect(() => {
  //   loadCoursesHandler();
  // }, []);

  return (
    <ul className="CourseListPage-list">
        <li className="CourseListPage-item">
        </li>
    </ul>
  );
};

export default WithLayout(CourseListPage);
