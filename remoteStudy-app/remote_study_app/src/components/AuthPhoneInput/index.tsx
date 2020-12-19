import * as React from "react"
import MuiPhoneNumber from "material-ui-phone-number"
import { makeStyles } from "@material-ui/core/styles"

export interface AuthPhoneInputProps {
  handleInputChange: any
  name: String
  label: String
}
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
}))
const AuthPhoneInput: React.SFC<AuthPhoneInputProps> = ({
  handleInputChange,
  name,
  label,
}) => {
  const classes = useStyles()

  return (
    <MuiPhoneNumber
      onChange={handleInputChange}
      label={label}
      name={name.toLowerCase()}
      size='small'
      variant='outlined'
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
  )
}

export default AuthPhoneInput
