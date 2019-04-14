import React from "react";
import { Link } from "react-router-dom";
import { Icon } from "components/Icon/Icon";
import "./NavMenu.scss";

function NavMenu(props) {

  return (
    <nav className="navbar border-bottom box-shadow mb-3 bg-accent text-theme" role="navigation">
      <div className="container-fluid">
        <div className="navbar-header navbar-left pull-left">
          <button className="btn btn-theme mr-2" id="nav-toggler" type="button" onClick={props.toggleSidebar}>
            <Icon icon="align-left" />
          </button>
          <span className="navbar-brand">Leagueen</span>
        </div>
        <ul className="navbar-nav flex-row float-right">

          <li className="nav-item">
            {
              props.user.isLoggedIn ?
                <Link className="nav-link text-theme" to="/logout"><Icon icon="sign-out-alt" /> Logout</Link> :
                <Link className="nav-link text-theme" to="/login"><Icon icon="sign-in-alt" /> Login</Link>
            }
          </li>
        </ul>
      </div>
    </nav>
  );
};

export { NavMenu };
