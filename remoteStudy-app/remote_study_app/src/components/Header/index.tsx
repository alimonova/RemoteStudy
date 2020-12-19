import React, { ReactElement } from "react"
import { Switch } from "../Switches"

interface Props {}

export default function Header({}: Props): ReactElement {
  return (
    <div>
      <Switch />
      Header
    </div>
  )
}
