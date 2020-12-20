import React, { ReactElement, useRef } from "react"
import classes from "./style.module.scss"
import { useDetectOutsideClick } from "../../../hoc"
import { H1, H2, H3, H4, Span14 } from "../../Text"

interface Props {}

export default function Select({}: Props): ReactElement {
  const ref = useRef<HTMLDivElement>(null)
  const [isActive, setIsActive] = useDetectOutsideClick(ref)

  return (
    <div ref={ref}>
      <span></span>
      <H1 onClick={() => setIsActive(!isActive)}>test</H1>
      {/* <H1 onClick={() => setIsActive(!isActive)} className={classes.header}>
        My courses
      </H1> */}
      {isActive && <div>children</div>}
    </div>
  )
}
