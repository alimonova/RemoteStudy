import React, { ReactChild } from 'react';
import classes from './style.module.scss';
import * as CSS from 'csstype';
import { txt } from '../../../utils';

type TStyle = CSS.Properties<0 | (string & {}), string & {}> | undefined

interface Itypography {
  children?: ReactChild | ReactChild[]
  className?: string
  style?: TStyle
  light?: boolean
}

function getParams(style: TStyle, activeClass: string, newClass: string | undefined, light?: boolean): object {  
  if (light) return {style, className: txt.join([activeClass, newClass, classes.light])} 
  return {style, className: txt.join([activeClass, newClass])} 
}

export const H1 = ({ children, className, style, light }:Itypography) => <h1 {...getParams(style, classes.H1, className, light)}>{children}</h1>
export const H2 = ({ children, className, style, light }:Itypography) => <h2 {...getParams(style, classes.H2, className, light)}>{children}</h2>
export const H3 = ({ children, className, style, light }:Itypography) => <h3 {...getParams(style, classes.H3, className, light)}>{children}</h3>
export const H4 = ({ children, className, style, light }:Itypography) => <h4 {...getParams(style, classes.H4, className, light)}>{children}</h4>
export const H5 = ({ children, className, style, light }:Itypography) => <h5 {...getParams(style, classes.H5, className, light)}>{children}</h5>
export const H6 = ({ children, className, style, light }:Itypography) => <h6 {...getParams(style, classes.H6, className, light)}>{children}</h6>
export const P10 = ({ children, className, style, light }:Itypography) => <p {...getParams(style, classes.P10, className, light)}>{children}</p>
export const P12 = ({ children, className, style, light }:Itypography) => <p {...getParams(style, classes.P12, className, light)}>{children}</p>
export const P14 = ({ children, className, style, light }:Itypography) => <p {...getParams(style, classes.P14, className, light)}>{children}</p>
export const P16 = ({ children, className, style, light }:Itypography) => <p {...getParams(style, classes.P16, className, light)}>{children}</p>
export const P18 = ({ children, className, style, light }:Itypography) => <p {...getParams(style, classes.P18, className, light)}>{children}</p>
export const P24 = ({ children, className, style, light }:Itypography) => <p {...getParams(style, classes.P24, className, light)}>{children}</p>
export const Span10 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span10, className, light)}>{children}</span>
export const Span12 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span12, className, light)}>{children}</span>
export const Span14 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span14, className, light)}>{children}</span>
export const Span16 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span16, className, light)}>{children}</span>
export const Span18 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span18, className, light)}>{children}</span>
export const Span24 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span24, className, light)}>{children}</span>
export const Span30 = ({ children, className, style, light }:Itypography) => <span {...getParams(style, classes.Span30, className, light)}>{children}</span>
export const Span12bold = ({ children, className, style }:Itypography) => <span {...getParams(style, classes.Span12bold, className)}>{children}</span>
export const Span14bold = ({ children, className, style }:Itypography) => <span {...getParams(style, classes.Span14bold, className)}>{children}</span>
export const Span16bold = ({ children, className, style }:Itypography) => <span {...getParams(style, classes.Span16bold, className)}>{children}</span>
export const Span18bold = ({ children, className, style }:Itypography) => <span {...getParams(style, classes.Span18bold, className)}>{children}</span>
