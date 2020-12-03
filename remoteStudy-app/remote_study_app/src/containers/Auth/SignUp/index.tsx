import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import { makeStyles, withStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Switch from "@material-ui/core/Switch";
import logoSvg from "../../../assets/icons/logo.svg";
import api, { apiServer } from "../../../api";
import AuthTextField from "../../../components/AuthTextField";
import AuthPhoneInput from "../../../components/AuthPhoneInput";
import axios from "axios";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Formik } from "formik";

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
const useStyles = makeStyles((theme) => ({
  container: {
    padding: theme.spacing(3),
    maxWidth: "600px",
  },
  titleText: {
    marginBottom: "30px",
  },
}));
const SignUpForm = () => {
  const initialValues = {
    email: "",
    password: "",
    firstName: "",
    lastName: "",
    middleName: "",
  };
  const onSubmit = (values) => {};
  const validationSchema = Yup.object({
    email: Yup.string().email("Invalid email format").required("Required"),
    firstName: Yup.string()
      .required("First name Required")
      .min(2, "Name is too short"),
    lastName: Yup.string()
      .required("Last name Required")
      .min(2, "Last name is too short"),
    middleName: Yup.string()
      .required("Middle name Required")
      .min(2, "Middle name is too short"),
    password: Yup.string()
      .required("Required")
      .min(8, "Password is too short - should be 8 chars minimum."),
  });

  const formik = useFormik({
    initialValues,
    onSubmit,
    validationSchema,
  });

  const btnClasses = useStylesForBtn();
  const classes = useStyles();
  const history = useHistory();

  const [registrationData, setRegistrationData] = useState({
    // email: "",
    // firstName: "",
    // lastName: "",
    // middleName: "",
    // password: "",
    phoneNumber: "",
    checkTeacher: false,
  });

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    if (event.target.name === "checkTeacher") {
      setRegistrationData({
        ...registrationData,
        [event.target.name]: !registrationData.checkTeacher,
      });
    } else {
      setRegistrationData({ ...registrationData, [event.target.name]: value });
    }
  };

  const handleClick = (data) => {
    console.log();
    apiServer({
      api: api.auth.register,
      body: {...data,...registrationData},
    }).then((res) => {
      if (!res.err) {
        history.push("/login");
        console.log("SUCCESS");
      } else {
        console.log(res.err);
      }
    });
  };

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
                    <AuthTextField
                      helperText={
                        formik.touched.email ? formik.errors.email : ""
                      }
                      error={
                        formik.touched.email && Boolean(formik.errors.email)
                      }
                      formikProps={formik.getFieldProps("email")}
                      label="Email"
                      name="email"
                      type="email"
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <AuthTextField
                      helperText={
                        formik.touched.firstName ? formik.errors.firstName : ""
                      }
                      error={
                        formik.touched.firstName &&
                        Boolean(formik.errors.firstName)
                      }
                      formikProps={formik.getFieldProps("firstName")}
                      label="First Name"
                      name="firstName"
                      type="text"
                    />
                  </Grid>

                  <Grid item xs={4}>
                    <AuthTextField
                      helperText={
                        formik.touched.lastName ? formik.errors.lastName : ""
                      }
                      error={
                        formik.touched.lastName &&
                        Boolean(formik.errors.lastName)
                      }
                      formikProps={formik.getFieldProps("lastName")}
                      label="Last Name"
                      name="lastName"
                      type="text"
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <AuthTextField
                      helperText={
                        formik.touched.middleName ? formik.errors.middleName : ""
                      }
                      error={
                        formik.touched.middleName &&
                        Boolean(formik.errors.middleName)
                      }
                      formikProps={formik.getFieldProps("middleName")}
                      label="Middle Name"
                      name="middleName"
                      type="text"
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <AuthPhoneInput
                      handleInputChange={(value) =>
                        setRegistrationData({
                          ...registrationData,
                          phoneNumber: value,
                        })
                      }
                      label="Phone number"
                      name="phoneNumber"
                    />
                  </Grid>
                  <Grid component="label" container alignItems="center">
                    {" "}
                    <Grid>
                      <Typography style={{ marginLeft: "10px" }}>
                        Teacher
                      </Typography>
                    </Grid>
                    <CustomSwitch
                      checked={registrationData.checkTeacher}
                      onChange={handleInputChange}
                      name="checkTeacher"
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <AuthTextField
                      helperText={
                        formik.touched.password ? formik.errors.password : ""
                      }
                      error={
                        formik.touched.password &&
                        Boolean(formik.errors.password)
                      }
                      formikProps={formik.getFieldProps("password")}
                      label="Password"
                      name="password"
                      type="password"
                    />
                  </Grid>
                </Grid>
              </Grid>
              <Grid item xs={12}>
                <Button
                  fullWidth
                  disabled={Object.entries(formik.errors).length !== 0}
                  // type="submit"
                  variant="contained"
                  classes={{
                    root: btnClasses.root, // class name, e.g. `classes-nesting-root-x`
                    label: btnClasses.label, // class name, e.g. `classes-nesting-label-x`
                  }}
                  onClick={() => handleClick(formik.values)}
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
