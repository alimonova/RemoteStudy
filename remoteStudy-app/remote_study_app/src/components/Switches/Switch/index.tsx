import React, { ReactElement } from "react"
import classes from "./style.module.scss"

interface Props {}

export default function Switch({}: Props): ReactElement {
  return <div className={classes.switch}>Switch</div>
}
