import React, { ReactElement, useState } from "react"
import { Switch } from "../Switches"

interface Props {}

export default function Header({}: Props): ReactElement {
  const [isActive, setIsActive] = useState(false)

  return (
    <div>
      <Switch value={isActive} onChange={(v) => setIsActive(v)} />
      Header
    </div>
  )
}
