import React, {PropTypes} from 'react';
import { Link, IndexLink } from 'react-router';
import LoadingDots from '../common/LoadingDots';
import {connect} from 'react-redux';
import { Navbar, Nav, NavItem } from 'react-bootstrap';

const Header = ({loading}) => {
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

Header.propTypes = {
  loading: PropTypes.bool.isRequired
};

export default Header;
