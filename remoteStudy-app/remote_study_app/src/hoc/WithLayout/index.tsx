import React, { useState } from "react";
import "./style.scss";

import Sidebar from "../../components/Sidebar";
import { render } from "@testing-library/react";

interface State {
  isOpen: boolean;
}

const WithLayout = (Component: React.ComponentType) => {
  return class ModifiedComponents extends React.Component<State> {
    state: Readonly<State> = {
      isOpen: false,
    };

    render() {
      const { isOpen } = this.state;

      return (
        <div className="WithLayout__layout">
          <header className="app-header">hhh</header>
          <Sidebar
            isOpen={isOpen}
            setOpen={(isOpen) => this.setState({ isOpen })}
          />
          <div className="WithLayout__main">
            <Component {...this.props} />
          </div>
          <footer className="app-footer">sss</footer>
        </div>
      );
    }
  };
};

// function WithLayout<T>(Component: React.ComponentType<T>) {
//   return (props: T) => {
//     const [isOpen, setIsOpen] = useState(false);
//     return (
//       <div className="WithLayout__layout">
//         <header className="app-header">hhh</header>
//         <Sidebar isOpen={isOpen} setOpen={setIsOpen} />
//         <div className="WithLayout__main">
//           <Component {...props} />
//         </div>
//         <footer className="app-footer">sss</footer>
//       </div>
//     );
//   };
// }

export default WithLayout;
