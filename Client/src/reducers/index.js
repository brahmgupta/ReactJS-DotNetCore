import {combineReducers} from 'redux';
import palindromes from './palindromeReducer';

const rootReducer = combineReducers({
  palindromes
});

export default rootReducer;
