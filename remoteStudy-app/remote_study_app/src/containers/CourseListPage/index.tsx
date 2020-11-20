import React, { useCallback, useEffect } from "react";
import Container from "@material-ui/core/Container";
import { useDispatch } from "react-redux";
import { useShallowEqualSelector } from "../../utils/hooks";

import WithLayout from "../../hoc/WithLayout";
import { CourseCard } from "../../components/Cards";

import coursesActions from "../../modules/courseList/actions";

interface ICourseListPageProps {}

const CourseListPage = () => {
  /** REDUX STATE */
  const courseList = useShallowEqualSelector(
    ({ courseList }) => courses.courseList
  );

  /** REDUX ACTIONS */
  const dispatch = useDispatch();

  const loadCoursesHandler = useCallback(() => {
    dispatch(coursesActions.loadCourses());
  }, [dispatch]);

  /** USE EFFECTS */
  useEffect(() => {
    loadCoursesHandler();
  }, []);

  return (
    <ul className="CourseListPage-list">
      {courseList.map((course) => (
        <li className="CourseListPage-item">
          <CourseCard course={course}></CourseCard>
        </li>
      ))}
    </ul>
  );
};

export default WithLayout(CourseListPage);
