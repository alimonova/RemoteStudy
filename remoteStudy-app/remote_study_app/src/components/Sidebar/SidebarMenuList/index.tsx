import * as React from "react";
import clsx from "clsx";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import Typography from "@material-ui/core/Typography";

import {
  BookIcon,
  PlusInSquareIcon,
  CalendarIcon,
  GearIcon,
  PaletteIcon,
  LogOutIcon,
} from "../../Icons";

import styles from "./style.module.scss";
import useStyles from "./materialStyles";

interface ISidebarMenuProps {
  isOpen: boolean;
}

const studyItems = [
  {
    icon: (
      <BookIcon className={[styles["icon"], styles["icon-stroke"]].join(" ")} />
    ),
    title: "My courses",
  },
  {
    icon: (
      <PlusInSquareIcon
        className={[styles["icon"], styles["icon-fill"]].join(" ")}
      />
    ),
    title: "Add course",
  },
  {
    icon: (
      <CalendarIcon
        className={[styles["icon"], styles["icon-fill"]].join(" ")}
      />
    ),
    title: "Add course",
  },
];

const accountItems = [
  {
    icon: (
      <GearIcon className={[styles["icon"], styles["icon-stroke"]].join(" ")} />
    ),
    title: "Settings",
  },
  {
    icon: (
      <PaletteIcon
        className={[styles["icon"], styles["icon-fill"]].join(" ")}
      />
    ),
    title: "Themes",
  },
];

const SidebarMenuList = ({ isOpen }: ISidebarMenuProps) => {
  const classes = useStyles();

  return (
    <>
      {isOpen && (
        <Typography
          variant="h6"
          component="h3"
          classes={{ root: clsx(classes.section) }}
        >
          Study
        </Typography>
      )}
      <List>
        {studyItems.map((item, idx) => (
          <ListItem classes={{ root: clsx(classes.item) }} button key={idx}>
            <ListItemIcon className={styles["icon-wrapper"]}>
              {item.icon}
            </ListItemIcon>
            {isOpen && (
              <ListItemText className={styles["text-wrapper"]}>
                <Typography variant="body1" component="p">
                  {item.title}
                </Typography>
              </ListItemText>
            )}
          </ListItem>
        ))}
      </List>
      {isOpen && (
        <Typography
          variant="h6"
          component="h3"
          classes={{ root: clsx(classes.section) }}
        >
          Account
        </Typography>
      )}
      <List>
        {accountItems.map((item, idx) => (
          <ListItem classes={{ root: clsx(classes.item) }} button key={idx}>
            <ListItemIcon className={styles["icon-wrapper"]}>
              {item.icon}
            </ListItemIcon>
            {isOpen && (
              <ListItemText className={styles["text-wrapper"]}>
                <Typography variant="body1" component="p">
                  {item.title}
                </Typography>
              </ListItemText>
            )}
          </ListItem>
        ))}
      </List>
      <div className={styles["log-out"]}>
        <div>
          <LogOutIcon
            className={[styles["icon"], styles["icon-fill"]].join(" ")}
          />
        </div>
        <div className={styles["log-out-text"]}>
          <Typography variant="body1" component="p">
            Log out
          </Typography>
        </div>
      </div>
    </>
  );
};

export default SidebarMenuList;
