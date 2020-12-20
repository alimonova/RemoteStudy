import React, { ReactElement, useRef } from "react"
import classes from "./style.module.scss"
import { useDetectOutsideClick } from "../../../hoc"

interface Props {}

export default function Select({}: Props): ReactElement {
  const ref = useRef<HTMLDivElement>(null)
  const [isActive, setIsActive] = useDetectOutsideClick(ref)

  return (
    <div ref={ref}>
      <div onClick={() => setIsActive(!isActive)} className={classes.header}>
        header
      </div>
      {isActive && <div>children</div>}
    </div>
  )
}
