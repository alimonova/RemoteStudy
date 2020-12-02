import * as React from "react";
import clsx from "clsx";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import Typography from "@material-ui/core/Typography";

import styles from "./style.module.scss";

interface IClasses {
  root?: string;
  item?: string;
  icon?: string;
  text?: string;
}

interface ITitleWithIconList {
  icon: JSX.Element;
  title: string;
}

interface ITitleWithIconListProps {
  list: ITitleWithIconList[];
  isOpen: boolean;
  classes?: IClasses;
}

const TitleWitchIconList = ({
  list,
  isOpen,
  classes,
}: ITitleWithIconListProps) => {
  return (
    <List classes={{ root: clsx(classes?.root) }}>
      {list.map((item, idx) => (
        <ListItem classes={{ root: clsx(classes?.item) }} button key={idx}>
          <ListItemIcon className={styles["icon-wrapper"]} classes={{ root: clsx(classes?.icon) }}>
            {item.icon}
          </ListItemIcon>
          {isOpen && (
            <ListItemText className={styles["text-wrapper"]} classes={{ root: clsx(classes?.text) }}>
              <Typography variant="body2" component="p">
                {item.title}
              </Typography>
            </ListItemText>
          )}
        </ListItem>
      ))}
    </List>
  );
};

export default TitleWitchIconList;
