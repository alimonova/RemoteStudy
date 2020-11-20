import * as React from "react";
import clsx from "clsx";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import Typography from "@material-ui/core/Typography";

import allCoursesSvg from "../../../assets/icons/allCourses.svg";
import addCourseSvg from "../../../assets/icons/addCourse.svg";

import styles from "./style.module.scss";
import useStyles from "./materialStyles";

interface ISidebarMenuProps {
  isOpen: boolean;
}

const SidebarMenuList = ({ isOpen }: ISidebarMenuProps) => {
  const classes = useStyles();

  return (
    <List>
      {["My courses", "Add course"].map((text, index) => (
        <ListItem classes={{ root: clsx(classes.root) }} button key={text}>
          <ListItemIcon className={styles["icon-wrapper"]}>
            {index === 0 ? (
              <img src={allCoursesSvg} alt="logo" className={styles.icon} />
            ) : (
              <img src={addCourseSvg} alt="logo" className={styles.icon} />
            )}
          </ListItemIcon>
          {isOpen && (
            <ListItemText className={styles["text-wrapper"]}>
              <Typography variant="body2" component="p">
                {text}
              </Typography>
            </ListItemText>
          )}
        </ListItem>
      ))}
    </List>
  );
};

export default SidebarMenuList;
