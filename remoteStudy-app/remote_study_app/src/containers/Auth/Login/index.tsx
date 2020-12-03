import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import { makeStyles } from "@material-ui/core/styles";
import logoSvg from "../../../assets/icons/logo.svg";
import Typography from "@material-ui/core/Typography";
import AuthTextField from "../../../components/AuthTextField";
import api, { apiServer } from "../../../api";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Formik } from "formik";

const useStyles = makeStyles((theme) => ({
  container: {
    padding: theme.spacing(3),
  },
  titleText: {
    marginBottom: "30px",
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
export interface LoginFormProps {}

function LoginForm() {
  const initialValues = {
    email: "",
    password: "",
  };
  const onSubmit = (values) => {};
  const validationSchema = Yup.object({
    email: Yup.string().email("Invalid email format").required("Required"),
    password: Yup.string()
      .required("Required")
      .min(8, "Password is too short - should be 8 chars minimum."),
  });

  const formik = useFormik({
    initialValues,
    onSubmit,
    validationSchema,
  });

  const classes = useStyles();
  const btnClasses = useStylesForBtn();
  const history = useHistory();
  const [authorizationData, setauthorizationData] = useState({
    email: "",
    password: "",
  });
  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    setauthorizationData({ ...authorizationData, [event.target.name]: value });
  };

  const handleClick = (data) => {
    console.log(data);

    apiServer({
      api: api.auth.login,
      body: authorizationData,
    }).then((res) => {
      if (!res.err) {
        history.push("/courses");
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
              Login Form
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <AuthTextField
                      formikProps={formik.getFieldProps("email")}
                      helperText={
                        formik.touched.email ? formik.errors.email : ""
                      }
                      error={
                        formik.touched.email && Boolean(formik.errors.email)
                      }
                      label="email"
                      name="email"
                      type="email"
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <AuthTextField
                      formikProps={formik.getFieldProps("password")}
                      helperText={
                        formik.touched.password ? formik.errors.password : ""
                      }
                      error={
                        formik.touched.password &&
                        Boolean(formik.errors.password)
                      }
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
                  // type="submit"
                  variant="contained"
                  classes={{
                    root: btnClasses.root, // class name, e.g. `classes-nesting-root-x`
                    label: btnClasses.label, // class name, e.g. `classes-nesting-label-x`
                  }}
                  onClick={() => handleClick(formik.values)}
                >
                  Log in
                </Button>
              </Grid>
            </Grid>
          </form>
          <img
            src={logoSvg}
            alt="logo"
            className="auth-container__logo rotating"
          />
          {/* <h1 style={{ color: "#fff" }}>Login</h1> */}
        </div>
      </div>
    </>
  );
}

export default LoginForm;
