import React, { useState } from "react";
import clsx from "clsx";
import Sidebar from "../../components/Sidebar";
import { render } from "@testing-library/react";
import {
  createStyles,
  makeStyles,
  useTheme,
  Theme,
} from "@material-ui/core/styles";

import "./style.scss";

import { MainSwitch } from "../../components/Switches";

const drawerWidth = 280;
const closeDrawerWidth = 110;

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    content: {
      marginLeft: closeDrawerWidth,
      padding: "24px 24px 0px 24px",
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

interface State {
  isOpen?: boolean;
}

function WithLayout<T>(Component: React.ComponentType<T>) {
  const WithLayoutComponent = (props: any) => {
    const [isOpen, setIsOpen] = useState(false);
    const classes = useStyles();
    return (
      <div className="WithLayout">
        <Sidebar isOpen={isOpen} setOpen={setIsOpen} />
        <div
          className={clsx(
            classes.content,
            { [classes.contentShift]: isOpen },
            "WithLayout__layout"
          )}
        >
          <header className="WithLayout__layout-header">
            <MainSwitch />
          </header>

          <div className="WithLayout__layout-content">
            <Component {...props} />
          </div>
          <footer className="WithLayout__layout-footer">sss</footer>
        </div>
      </div>
    );
  };
  return WithLayoutComponent;
}

export default WithLayout;
