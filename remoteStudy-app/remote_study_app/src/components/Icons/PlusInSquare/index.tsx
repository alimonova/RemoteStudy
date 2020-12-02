import React from "react";
import IDefaultIconProps from "../IDefaultIconProps";

const PlusInSquareIcon = ({
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
      viewBox="0 0 30 30"
      className={className}
    >
      <path
        id="Icon_material-add-box"
        data-name="Icon material-add-box"
        d="M31.167,4.5H7.833A3.332,3.332,0,0,0,4.5,7.833V31.167A3.332,3.332,0,0,0,7.833,34.5H31.167A3.343,3.343,0,0,0,34.5,31.167V7.833A3.343,3.343,0,0,0,31.167,4.5ZM27.833,21.167H21.167v6.667H17.833V21.167H11.167V17.833h6.667V11.167h3.333v6.667h6.667Z"
        transform="translate(-4.5 -4.5)"
        fill={color}
      />
    </svg>
  );
};

export default PlusInSquareIcon;
