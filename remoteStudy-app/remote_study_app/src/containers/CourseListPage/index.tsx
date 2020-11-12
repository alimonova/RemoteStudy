import * as React from "react";
import Drawer from "@material-ui/core/Drawer";

import logoSvg from "../../assets/icons/logo.svg";

interface ICourseListPageProps {}

const CourseListPage = (props: any) => {
  return (
    <Drawer variant="permanent">
      <img src={logoSvg} alt="logo" />{" "}
    </Drawer>
  );
};

export default CourseListPage;
