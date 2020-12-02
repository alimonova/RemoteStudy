import React, { useState } from "react";
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import { makeStyles, withStyles } from "@material-ui/core/styles";
import logoSvg from "../../../assets/icons/logo.svg";
import Typography from "@material-ui/core/Typography";
import MuiPhoneNumber from "material-ui-phone-number";
import Switch from "@material-ui/core/Switch";

export interface SignUpFormProps {}
const CustomSwitch = withStyles({
  switchBase: {
    color: "#7f8c8d",
    "&$checked": {
      color: " #55D2A2",
    },
    "&$checked + $track": {
      backgroundColor: " #55D2A2",
    },
  },
  checked: {},
  track: {},
})(Switch);
const useStyles = makeStyles((theme) => ({
  container: {
    padding: theme.spacing(3),
    maxWidth: "600px",
  },
  titleText: {
    marginBottom: "30px",
  },
  cssLabel: {
    color: "#fff",
    "&$cssFocused": {
      color: "#fff",
    },
  },
  focusedLabel: {},

  cssFocused: {
    color: "#fff",
  },
  cssOutlinedInput: {
    color: "#fff",
    "&$cssFocused $notchedOutline": {
      borderColor: `#fff !important`,
    },
  },
  notchedOutline: {
    borderWidth: "2px",
    borderColor: "#fff !important",
  },
}));

const useStylesForBtn = makeStyles((theme) => ({
  root: {
    background: "linear-gradient(45deg, #5AC098 30%, #55D2A2 90%)",
    borderRadius: 3,
    border: 0,
    color: "white",
    height: 48,
    padding: "0 30px",
    // boxShadow: '0 3px 5px 2px #5AC098',
  },
  label: {
    textTransform: "capitalize",
  },
}));

const SignUpForm = () => {
  const classes = useStyles();
  const btnClasses = useStylesForBtn();

  const [registrationData, setRegistrationData] = useState({
    email: "",
    firstName: "",
    lastName: "",
    middleName: "",
    phoneNumber: "",
    password: "",
    checkTeacher: false,
  })

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value
    if (event.target.name === "checkTeacher") {
      setRegistrationData({...registrationData, [event.target.name]: !registrationData.checkTeacher});
    } else {
      setRegistrationData({...registrationData, [event.target.name]: value});
    }
  };

  const handleClick = () => {
    console.log(registrationData)
  }

  return (
    <>
      <div className="content-wrapper">
        <div className="auth-container">
          <form className={classes.container}>
            <Typography variant="h1" className={classes.titleText}>
              SignUp Form
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <TextField
                      fullWidth
                      value={registrationData.email}
                      onChange={handleInputChange}
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
                        },
                      }}
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <TextField
                      fullWidth
                      value={registrationData.firstName}
                      onChange={handleInputChange}
                      label="First Name"
                      name="firstName"
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
                        },
                      }}
                    />
                  </Grid>

                  <Grid item xs={4}>
                    <TextField
                      fullWidth
                      value={registrationData.lastName}
                      onChange={handleInputChange}
                      label="Last Name"
                      name="lastName"
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
                        },
                      }}
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <TextField
                      fullWidth
                      value={registrationData.middleName}
                      onChange={handleInputChange}
                      label="Middle Name"
                      name="middleName"
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
                        },
                      }}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <MuiPhoneNumber
                      onChange={(value) => setRegistrationData({...registrationData, phoneNumber: value})}
                      label="Phone number"
                      name="phoneNumber"
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
                        },
                      }}
                    />
                  </Grid>
                  <Grid
                    component="label"
                    container
                    alignItems="center"
                  > <Grid><Typography style={{marginLeft:'10px'}}>Teacher</Typography></Grid>
                    <CustomSwitch
                      checked={registrationData.checkTeacher}
                      onChange={handleInputChange}
                      name="checkTeacher"
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <TextField
                      fullWidth
                      value={registrationData.password}
                      onChange={handleInputChange}
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
                        },
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
                  onClick={handleClick}
                >
                  Sign up
                </Button>
              </Grid>
            </Grid>
          </form>
          <img
            src={logoSvg}
            alt="logo"
            className="auth-container__logo rotating"
          />
        </div>
      </div>
    </>
  );
};

export default SignUpForm;
