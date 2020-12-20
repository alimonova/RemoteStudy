import React, { ReactElement, useState } from "react"
import { ProgressBar } from "../ProgressBars"
import { Select } from "../Selects"
import { Switch } from "../Switches"
import classes from "./style.module.scss"

interface Props {}

export default function Header({}: Props): ReactElement {
  const [isActive, setIsActive] = useState(false)

  return (
    <header className={classes.header}>
      <ProgressBar className={classes.progress_bar} value={isActive ? 10 : 80} />
      <Select />
      <Switch
        value={isActive}
        onChange={(v) => setIsActive(v)}
        className={classes.switch}
      />
    </header>
  )
}
