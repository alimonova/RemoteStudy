import * as React from 'react';
import TextField from "@material-ui/core/TextField";
import { makeStyles, withStyles } from "@material-ui/core/styles";
export interface AuthTextFieldProps {
  name: String,
  label: String,
  type: string,
  formikProps: any,
  error: any,
  helperText: any
}
const useStyles = makeStyles((theme) => ({
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

 
const AuthTextField: React.SFC<AuthTextFieldProps> = ({name, label,type,formikProps, error, helperText}) => {
  const classes = useStyles();
  return (  
    <TextField
    fullWidth
    error={error}
    helperText={helperText}
    {...formikProps} // has onChange property
    type={type}
    label={label}
    // name={name.toLowerCase()}
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
  );
}
 
export default AuthTextField;