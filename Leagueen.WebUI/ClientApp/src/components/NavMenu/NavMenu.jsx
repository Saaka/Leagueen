import React, { useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.scss';

function NavMenu(props) {
  const [collapsed, setCollapsed] = useState(true);

  function toggleNavbar() {
    setCollapsed(!collapsed);
  }

  return (
      <nav className="navbar navbar-light navbar-expand-md navbar-toggleable-md ng-white border-bottom box-shadow mb-3">
        <div className="container-fluid">
          <button className="mr-2 navbar-toggler" type="button" onClick={props.toggleSidebar}>
            <span className="navbar-toggler-icon"></span>
          </button>
          <NavbarBrand tag={Link} to="/">Leagueen</NavbarBrand>
          <Collapse className="d-md-inline-flex flex-md-row-reverse" isOpen={!collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </div>
      </nav>
  );
};

export { NavMenu };
