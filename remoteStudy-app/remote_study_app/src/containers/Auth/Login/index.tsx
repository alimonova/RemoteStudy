import * as React from "react";
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import { makeStyles } from "@material-ui/core/styles";
import logoSvg from '../../../assets/icons/logo.svg';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles((theme) => ({
  container: {
    padding: theme.spacing(3),
  },
  titleText: {
    marginBottom: '30px'
  },
  cssLabel: {
    color : '#fff',
    "&$cssFocused": {
      color: "#fff"
    },
  },
  focusedLabel: {},

  cssFocused: {
    color : '#fff'
  },
  cssOutlinedInput: {
    color: '#fff',
    '&$cssFocused $notchedOutline': {
      borderColor: `#fff !important`,
    }
  },
  notchedOutline: {
    borderWidth: '2px',
    borderColor: '#fff !important',
  },
}));

const useStylesForBtn = makeStyles((theme) => ({
  root: {
    background: 'linear-gradient(45deg, #5AC098 30%, #55D2A2 90%)',
    borderRadius: 3,
    border: 0,
    color: 'white',
    height: 48,
    padding: '0 30px',
    // boxShadow: '0 3px 5px 2px #5AC098',
  },
  label: {
    textTransform: 'capitalize',
  },
}));
export interface LoginFormProps {}

function LoginForm ()  {
  const classes = useStyles();
  const btnClasses = useStylesForBtn();
  return (
    <>
      <div className="content-wrapper">
        <div className="auth-container">
            <form className={classes.container}>
             <Typography variant="h1" className={classes.titleText}>Login Form</Typography>
              <Grid container spacing={3}>
                <Grid item xs={12}>
                  <Grid container spacing={2}>
                    <Grid item xs={12}>
                      <TextField
                        fullWidth
                        label="Email"
                        name="email"
                        size="small"
                        variant="outlined"
                        InputLabelProps={{
                          classes: {
                            root: classes.cssLabel,
                            focused: classes.cssFocused,
                          },
                        }}
                        InputProps={{
                          classes: {
                            root: classes.cssOutlinedInput,
                            focused: classes.cssFocused,
                            notchedOutline: classes.notchedOutline,
                          }
                        }}
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <TextField
                        fullWidth
                        label="Password"
                        name="password"
                        size="small"
                        type="password"
                        variant="outlined"
                        InputLabelProps={{
                          classes: {
                            root: classes.cssLabel,
                            focused: classes.cssFocused,
                          },
                        }}
                        InputProps={{
                          classes: {
                            root: classes.cssOutlinedInput,
                            focused: classes.cssFocused,
                            notchedOutline: classes.notchedOutline,
                          }
                        }}
                      />
                    </Grid>
                  </Grid>
                </Grid>
                <Grid item xs={12}>
                  <Button
                    fullWidth
                    // type="submit"
                    variant="contained"
                    classes={{
                      root: btnClasses.root, // class name, e.g. `classes-nesting-root-x`
                      label: btnClasses.label, // class name, e.g. `classes-nesting-label-x`
                    }}
                  >
                    Log in
                  </Button>
                </Grid>
              </Grid>
            </form>
            <img src = {logoSvg} alt="logo" className="auth-container__logo rotating"/>
          {/* <h1 style={{ color: "#fff" }}>Login</h1> */}
        </div>
      </div>
    </>
  );
};

export default LoginForm;
