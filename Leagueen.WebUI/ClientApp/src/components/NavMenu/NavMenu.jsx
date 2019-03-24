import React from "react";
import { Link } from "react-router-dom";
import { Icon } from "components/Icon/Icon";
import "./NavMenu.scss";

function NavMenu(props) {

  return (
    <nav className="navbar border-bottom box-shadow mb-3 ng-white navbar-light" role="navigation">
      <div className="container-fluid">
        <div className="navbar-header navbar-left pull-left">
          <button className="navbar-toggler mr-2" type="button" onClick={props.toggleSidebar}>
            <Icon icon="align-left" />
          </button>
          <span className="navbar-brand">Leagueen</span>
        </div>
        <ul className="navbar-nav flex-row float-right">
          <li className="nav-item">
            <span className="navbar-text">Welcome, <strong>Guest</strong>!</span>
          </li>
          <li className="nav-item">
            {
              props.user.isLoggedIn ?
                <Link className="nav-link" to="/logout"> Logout</Link> :
                <Link className="nav-link" to="/login"> Login</Link>
            }
          </li>
        </ul>
      </div>
    </nav>
  );
};

export { NavMenu };
