import React, {PropTypes} from 'react';

const PalindromeListRow = ({palindrome}) => {
  return (
    <tr>
      <td>{palindrome.id}</td>
      <td>{palindrome.sequence}</td>
    </tr>
  );
};

PalindromeListRow.propTypes = {
  palindrome: PropTypes.object.isRequired
};

export default PalindromeListRow;
