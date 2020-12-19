import React, { ReactElement } from "react"
import { txt } from "../../../utils"
import { P12, Span14 } from "../../Text"
import classes from "./style.module.scss"

interface Props {
  className?: string
  value?: number
}

export default function ProgressBar(props: Props): ReactElement {
  const { className, value = 30 } = props

  return (
    <div className={txt.join([classes.progress_bar_wrapper, className])}>
      <P12 className={classes.title}>{value}% complete</P12>
      <div className={classes.progress_bar}>
        <div className={classes.body} style={{ width: `${value}%` }} />
      </div>
    </div>
  )
}
