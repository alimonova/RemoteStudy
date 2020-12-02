import React from "react";
import IDefaultIconProps from "../IDefaultIconProps";

const LogOutIcon = ({
  width = 25,
  height = 22,
  color = "#545557",
  className,
}: IDefaultIconProps) => {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width={width}
      height={height}
      viewBox="0 0 25.319 22.154"
      className={className}
    >
      <path
        id="Icon_open-account-logout"
        data-name="Icon open-account-logout"
        d="M9.494,0V3.165H22.154V18.989H9.494v3.165H25.319V0ZM6.33,6.33,0,11.077l6.33,4.747V12.659H18.989V9.494H6.33Z"
        fill={color}
      />
    </svg>
  );
};

export default LogOutIcon;
