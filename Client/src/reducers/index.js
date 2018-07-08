import {combineReducers} from 'redux';
import ajaxCallsInProgress from './ajaxStatusReducer';
import palindromes from './palindromeReducer';

const rootReducer = combineReducers({
  palindromes,
  ajaxCallsInProgress
});

export default rootReducer;
