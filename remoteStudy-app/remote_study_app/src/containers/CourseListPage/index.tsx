import React from "react"

import WithLayout from "../../hoc/WithLayout"

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
    <ul className='CourseListPage-list'>
      <li className='CourseListPage-item'></li>
    </ul>
  )
}

export default WithLayout(CourseListPage)
