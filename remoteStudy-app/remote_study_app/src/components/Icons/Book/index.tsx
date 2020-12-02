import React from "react";
import IDefaultIconProps from "../IDefaultIconProps";

const BookIcon = ({
  width = 33.448,
  height = 35.996,
  color = "#545557",
  className,
}: IDefaultIconProps) => {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width={width}
      height={height}
      viewBox="0 0 33.448 35.996"
      className={className}
    >
      <g
        id="Icon_feather-book"
        data-name="Icon feather-book"
        transform="translate(-4.5 -1.5)"
      >
        <path
          id="Контур_3"
          data-name="Контур 3"
          d="M6,30.352A4.805,4.805,0,0,1,10.757,25.5h25.69"
          transform="translate(0 0.793)"
          fill="none"
          stroke={color}
          strokeLinecap="round"
          strokeLinejoin="round"
          strokeWidth="3"
        />
        <path
          id="Контур_4"
          data-name="Контур 4"
          d="M10.757,3h25.69V36H10.757C8.13,36,6,34.15,6,31.872V7.125C6,4.847,8.13,3,10.757,3Z"
          transform="translate(0 0)"
          fill="none"
          stroke={color}
          strokeLinecap="round"
          strokeLinejoin="round"
          strokeWidth="3"
        />
      </g>
    </svg>
  );
};

export default BookIcon;
