import React from "react"
import classes from "./style.module.scss"
import { txt } from "../../../utils"

type TopographyType = React.DetailedHTMLProps<
  React.HTMLAttributes<HTMLHeadingElement>,
  HTMLHeadingElement
> & {
  islight?: boolean
}

function getProps(
  props: TopographyType,
  activeClass: string
): React.DetailedHTMLProps<React.HTMLAttributes<HTMLHeadingElement>, HTMLHeadingElement> {
  const { islight, className, ...lastProps } = props
  return {
    className: txt.join([activeClass, className, islight && classes.light]),
    ...lastProps,
  }
}

function newEl(Tag: string, classesName: string) {
  return ({ children, ...props }: TopographyType) => (
    <Tag {...getProps(props, classesName)}>{children}</Tag>
  )
}

const p = (c: string) => newEl("p", c)
const span = (c: string) => newEl("span", c)

export const H1 = newEl("h1", classes.H1)
export const H2 = newEl("h2", classes.H2)
export const H3 = newEl("h3", classes.H3)
export const H4 = newEl("h4", classes.H4)
export const H5 = newEl("h5", classes.H5)
export const H6 = newEl("h6", classes.H6)
export const P10 = p(classes.P10)
export const P12 = p(classes.P12)
export const P14 = p(classes.P14)
export const P16 = p(classes.P16)
export const P18 = p(classes.P18)
export const P24 = p(classes.P24)
export const Span10 = span(classes.Span10)
export const Span12 = span(classes.Span12)
export const Span14 = span(classes.Span14)
export const Span16 = span(classes.Span16)
export const Span18 = span(classes.Span18)
export const Span24 = span(classes.Span24)
export const Span30 = span(classes.Span30)
export const Span12bold = span(classes.Span12bold)
export const Span14bold = span(classes.Span14bold)
export const Span16bold = span(classes.Span16bold)
export const Span18bold = span(classes.Span18bold)
