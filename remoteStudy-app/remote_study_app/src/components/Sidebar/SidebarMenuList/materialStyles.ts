import {
  createStyles,
  makeStyles,
  useTheme,
  Theme,
} from "@material-ui/core/styles";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    item: {
      marginTop: "10px",
    },
    section: {
      color: "#545557",
      fontWeight: "bold",
      marginLeft: "20px",
      marginTop: "15px",
    }
  })
);

export default useStyles;
