import React, {PropTypes} from 'react';
import PalindromeListRow from './PalindromeListRow';
import {Table} from 'react-bootstrap';

const PalindromeList = ({palindromes}) => {
  return (
    <Table striped bordered condensed hover responsive>
      <thead>
      <tr>
        <th>ID</th>
        <th>Successfully entered Palindromes</th>
      </tr>
      </thead>
      <tbody>
      {palindromes.sort((a, b) => b.id - a.id).map(palindrome =>
        <PalindromeListRow key={palindrome.id} palindrome={palindrome}/>
      )}
      </tbody>
    </Table>
  );
};

PalindromeList.propTypes = {
  palindromes: PropTypes.array.isRequired
};

export default PalindromeList;
