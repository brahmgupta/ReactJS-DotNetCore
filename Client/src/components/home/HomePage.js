import React from  'react';
import {Link} from  'react-router';
import { Jumbotron } from 'react-bootstrap';

class HomePage extends React.Component{
    render(){
        return(
            <Jumbotron>
                <h1>Home</h1>
                <p>Web App created using ReactJS for NSW.Health Test</p>
                <p>This application is UI reponsive, try by resizing your window.</p>
                <Link to="palindrome">Go to Planidrome Check page</Link>
            </Jumbotron>
        );
    }
}

export default HomePage;
