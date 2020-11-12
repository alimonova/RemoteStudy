import * as React from "react";
import clsx from "clsx";
import Drawer from "@material-ui/core/Drawer";
import Button from "@material-ui/core/Button";
import { withStyles, WithStyles } from "@material-ui/core/styles";
import "./style.scss";

import logoSvg from "../../assets/icons/logo.svg";

const styles = {
  paper: {
    background: "#000",
  },
  docked: {
    background: "#000",
  },
};

interface ISidebarProps extends WithStyles<typeof styles> {
  children?: React.ReactNode;
  className?: string;
}

const Sidebar = ({ classes, children, className }: ISidebarProps) => {
  return (
    <Drawer variant="permanent" classes={classes}>
      <img src={logoSvg} alt="logo" className="logo" />{" "}
    </Drawer>
    // <Button className={clsx(classes.root, className)} {...other}>
    //   {children || "class names"}
    // </Button>
  );
};

export default withStyles(styles)(Sidebar);
