import * as types from './actionTypes';
import {get, post} from '../api/restApi';
import {beginAjaxCall, ajaxCallError} from './ajaxCallsActions';

export function loadPalindromesSuccess(palindromes) {
  return {type:types.LOAD_PALINDROMES_SUCCESS, palindromes};
}

export function checkSequenceSuccess(palindrome) {
  return {type:types.CHECK_SEQUENCE_SUCCESS, palindrome};
}

export function loadPalindromes(){
    return function(dispatch){
        dispatch(beginAjaxCall());
        return get({url:'Palindromes/'}).then(
          response => {
              dispatch(loadPalindromesSuccess(response.data));
          }).catch(error => {
              throw(error);
          });
        };
}

export function checkSequence(sequence){

  return function(dispatch, getState){
    dispatch(beginAjaxCall());

    return post({url:'Palindromes/', data:{sequence:sequence}}).then(
      response => {
        dispatch(checkSequenceSuccess(response.data));
      }).catch(error => {

       if(error.response === undefined) {
         throw(error.message);
       }
       else{
        throw(error.response.data.Sequence);
       }

      });
    };
  }
