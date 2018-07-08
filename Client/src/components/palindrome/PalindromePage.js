import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as palindromeActions from '../../actions/palindromeActions';
import toastr from 'toastr';
import * as bs from 'react-bootstrap';
import PalindromeList from './PalindromeList';

class PalindromePage extends React.Component {
  constructor(props, context) {
     super(props, context);

     this.handleChange = this.handleChange.bind(this);

     this.state = {
        saving: false,
        sequence: '',
        isPalindrome:''
     };

     this.checkSequence = this.checkSequence.bind(this);
   }

  handleChange(e) {
    this.setState({ sequence: e.target.value, isPalindrome:'' });
  }

  checkSequence(event){
    event.preventDefault();
    this.setState({saving: true});
    this.props.actions.checkSequence(this.state.sequence)
      .then(() => {
        this.setState({saving: false, isPalindrome:'success'});
        toastr.success('Sequence is Paindrome !!');
      })
      .catch(error => {
          this.setState({saving: false, isPalindrome:'error'});
          toastr.error(error);
      });
  }

  render() {

    const {palindromes} = this.props;

    return (
      <div>
        <bs.PageHeader>
          Palindrome <small>Check if sequence is palindrome</small>
        </bs.PageHeader>
        <bs.Form>
        <bs.FormGroup validationState={this.state.isPalindrome} bsSize="large">
            <bs.FormControl
              type="text"
              value={this.state.sequence}
              placeholder="Enter palindrome sequence"
              onChange={this.handleChange}
            />
            <bs.FormControl.Feedback />
            <bs.HelpBlock>Example - Never Odd or Even</bs.HelpBlock>
      </bs.FormGroup>
      <bs.FormGroup>
        <bs.Button
          type="submit"
          onClick={this.checkSequence}
          disabled={this.state.saving} >Check</bs.Button>
      </bs.FormGroup>

      </bs.Form>
      <hr/>
      {palindromes && palindromes.length > 0 && <PalindromeList palindromes={palindromes}/>}
      </div>
    );
  }
}

PalindromePage.propTypes = {
  palindromes: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired
};

PalindromePage.contextTypes = {
  router: PropTypes.object
};

function mapStateToProps(state, ownProps) {
  return {
    palindromes: state.palindromes
};
}

function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(palindromeActions, dispatch)
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(PalindromePage);
