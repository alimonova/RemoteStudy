import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import Skeleton from "@material-ui/lab/Skeleton";
import Rating from "@material-ui/lab/Rating";
import FavoriteBorderIcon from "@material-ui/icons/FavoriteBorder";
import FavoriteIcon from "@material-ui/icons/Favorite";
import classes from "./style.module.scss";
import PlaylistAddIcon from "@material-ui/icons/PlaylistAdd";
import PlaylistAddCheckIcon from "@material-ui/icons/PlaylistAddCheck";
import Avatar from '@material-ui/core/Avatar';

function CourseCard() {
  const [value, setValue] = React.useState<number | null>(2);
  const [fav, setFav] = React.useState(false);
  const [sub, setSub] = React.useState(true);
  const handleFavourite = () => {
    setFav((prev) => !prev);
  };
  return (
    <div className={classes.item}>
      <div className={classes.imagePlaceholder}></div>
      <div className={classes.ratingWrapper}>
        <Rating
          name="rating-controlled"
          value={value}
          precision={0.5}
          size="small"
          onChange={(event, newValue) => {
            setValue(newValue);
          }}
        />
        {fav ? (
          <FavoriteIcon
            onClick={handleFavourite}
            style={{ color: "#5AC098" }}
          />
        ) : (
          <FavoriteBorderIcon
            onClick={handleFavourite}
            style={{ color: "#5AC098" }}
          />
        )}
      </div>
      <h3 className={classes.title}>Design Thinking: The Beginner's guide</h3>
      <div className={classes.subscribeWrapper}>
        {!sub ? (
          <>
            <PlaylistAddIcon fontSize="large" />
            <span>subscribe</span>
          </>
        ) : (
          <>
            <PlaylistAddCheckIcon fontSize="large"  style={{ color: "#5AC098" }} />
            <span style={{ color: "#5AC098" }}>subscribed</span>
          </>
        )}
      </div>
      <div className={classes.teacherWrapper}>
        <Avatar className={classes.avatar}>NP</Avatar>
        <div className={classes.textContainer}>
          <span className={classes.teacherTitle}>Teacher: </span>
          <span className={classes.teacherSub}>Andrew Frankie</span>
        </div>
      </div>
    </div>
  );
}

export default CourseCard;
