import React from 'react';
import { Route, IndexRoute} from 'react-router';
import App from './components/App';
import HomePage from './components/home/HomePage';
import PalindromePage from './components/palindrome/PalindromePage';

export default(
    <Route path="/" component={App}>
        <IndexRoute component={HomePage} />
        <Route path="palindrome" component={PalindromePage} />
    </Route>
);
