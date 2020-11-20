import * as React from "react";
import clsx from "clsx";
import Drawer from "@material-ui/core/Drawer";
import Button from "@material-ui/core/Button";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import {
  createStyles,
  makeStyles,
  useTheme,
  Theme,
} from "@material-ui/core/styles";

import "./style.scss";

import logoSvg from "../../assets/icons/logo.svg";
import SidebarMenuList from "./SidebarMenuList";

const drawerWidth = 280;
const closeDrawerWidth = 110;

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    drawer: {
      width: drawerWidth,
      flexShrink: 0,
      whiteSpace: "nowrap",
    },
    drawerOpen: {
      width: drawerWidth,
      transition: theme.transitions.create("width", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
    },
    drawerClose: {
      transition: theme.transitions.create("width", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
      }),
      overflowX: "hidden",
      width: closeDrawerWidth,
    },
    paper: {
      // position: "relative",
      background: "#000",
      color: "#fff",
    },
    docked: {
      background: "#000",
    },
    content: {
      marginLeft: closeDrawerWidth,
      padding: theme.spacing(3),
      transition: theme.transitions.create(["width", "margin"], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
    },
    contentShift: {
      marginLeft: drawerWidth,
      transition: theme.transitions.create(["width", "margin"], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
      }),
    },
  })
);

interface ISidebarProps {
  isOpen: boolean;
  setOpen: (isOpen: boolean) => void;
}

const Sidebar = ({ isOpen, setOpen }: ISidebarProps) => {
  const classes = useStyles();
  const theme = useTheme();

  const toggleDrawerOpen = () => {
    setOpen(!isOpen);
  };

  return (
    <>
      <Drawer
        variant="permanent"
        classes={{
          paper: clsx(classes.paper, classes.docked, classes.drawer, {
            [classes.drawerOpen]: isOpen,
            [classes.drawerClose]: !isOpen,
          }),
        }}
        onClose={() => console.log(true)}
      >
        <div className="Sidebar__logo-wrapper">
          <img
            src={logoSvg}
            alt="logo"
            className="Sidebar__logo"
            onClick={toggleDrawerOpen}
          />
        </div>
        <SidebarMenuList isOpen={isOpen} />
        {/* <List>
          {["My courses"].map((text, index) => (
            <ListItem button key={text}>
              <ListItemIcon>
                <img
                  src={logoSvg}
                  alt="logo"
                  className="logo"
                  onClick={toggleDrawerOpen}
                />
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItem>
          ))}
        </List> */}
      </Drawer>
      {/* <div
        className={clsx(classes.content, { [classes.contentShift]: isOpen })}
      >
        Lorem ipsum dolor sit amet consectetur adipisicing elit. In dolore aut
        vel temporibus consequuntur, veniam commodi quam. Accusamus, nemo
        fugiat!
      </div> */}
      {/* <Button className={clsx(classes.root, className)} {...other}>
        {children || "class names"}
      </Button> */}
    </>
  );
};

export default Sidebar;
