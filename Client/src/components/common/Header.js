import React from 'react';
import { IndexLink } from 'react-router';
import { Navbar, Nav, NavItem } from 'react-bootstrap';

const Header = () => {
  return (

<Navbar collapseOnSelect>
  <Navbar.Header>
    <Navbar.Brand>
      <IndexLink to="/" activeClassName="active">Home</IndexLink>
    </Navbar.Brand>
    <Navbar.Toggle />
  </Navbar.Header>
  <Navbar.Collapse>
  <Nav>
    <NavItem eventKey={1} href="/palindrome">
      Palindrome Check
    </NavItem>
  </Nav>
  </Navbar.Collapse>
</Navbar>
  );
};

export default Header;
