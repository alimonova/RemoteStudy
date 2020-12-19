import React, { ReactElement, useState } from "react"
import { txt } from "../../../utils"
import classes from "./style.module.scss"

interface Props {
  value?: boolean
  onChange?: (value: boolean) => void
  isDisabled?: boolean
}

export default function Switch(props: Props): ReactElement {
  const { onChange, isDisabled } = props
  const [isActive, setIsActive] = useState(false)

  const value = props.value || isActive

  function changeActive() {
    if (isDisabled) return undefined
    if (typeof onChange === "function") {
      onChange(!value)
    } else {
      setIsActive(!isActive)
    }
  }

  return (
    <div
      className={txt.join([classes.switch, isDisabled && classes.is_disabled])}
      onClick={changeActive}
    >
      <div className={txt.join([classes.circle, value && classes.active])} />
    </div>
  )
}
