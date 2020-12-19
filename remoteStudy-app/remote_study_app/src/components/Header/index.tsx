import React, { ReactElement, useState } from "react"
import { ProgressBar } from "../ProgressBars"
import { Switch } from "../Switches"
import classes from "./style.module.scss"

interface Props {}

export default function Header({}: Props): ReactElement {
  const [isActive, setIsActive] = useState(false)

  return (
    <div>
      <ProgressBar className={classes.progress_bar} value={isActive ? 10 : 80} />
      <Switch value={isActive} onChange={(v) => setIsActive(v)} />
    </div>
  )
}
