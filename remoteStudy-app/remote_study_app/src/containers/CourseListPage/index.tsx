import React, { useCallback, useEffect } from "react";
import Container from "@material-ui/core/Container";
import { useDispatch } from "react-redux";
import { useShallowEqualSelector } from "../../utils/hooks";

import WithLayout from "../../hoc/WithLayout";
import { CourseCard } from "../../components/Cards";

interface ICourseListPageProps {}

const CourseListPage = () => {
  return (
    <CourseCard />
  );
};

export default WithLayout(CourseListPage);
