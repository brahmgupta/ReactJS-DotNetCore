import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function palindromeReducer(state = initialState.palindromes, action) {
  switch (action.type) {

    case types.LOAD_PALINDROMES_SUCCESS:
      return action.palindromes;

    case types.CHECK_SEQUENCE_SUCCESS:
      return [...state, Object.assign({}, action.palindrome)];

    default:
      return state;
  }
}
