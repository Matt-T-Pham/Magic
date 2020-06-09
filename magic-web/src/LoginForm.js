import React          from 'react';
import InputField     from './InputField';
import SubmitButton   from './SubmitButton';
import UserStore      from './Store/UserStore';


class LoginForm extends React.Component{

  constructor(props){
      super(props);
      this.state = {
        username:'',
        password:'',
        buttonDisabled: false
      }
  }

  setInputValue(property,val){
      val = val.trim();
      if(val.length>12){
        return;
      }
      this.setState({
        [property]: val
      })
  }

  resetForm(){
    this.setState({
      username:'',
      password:'',
      buttonDisabled: false
    })
  }

  async doLogin(){
    if(!this.state.username){
      return;
    }
    if(!this.state.password){
      return;
    }
    this.setState({
      buttonDisabled: true
    })
    try{
      let res = await fetch('/login',{
        method: 'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body:JSON.stringify({
          username: this.state.username,
          password: this.state.password
        })
      });
      let result = await res.json();
      if(result && result.success){
        UserStore.isLoggedIn = true;
        UserStore.username = result.username;
      }
      else if(result && result.success == false){
        this.resetForm();
        alert(result.msg);       
      }
    }
    catch(e){
      console.log(e);
      this.resetForm();
    }
  }
  render(){
    return (
      <div className="loginForm">
        Log In
        <InputField
          type='text'
          placeholder = 'Username'
          vale = {this.state.username ? this.state.username : ''}
          OnChange= {(val) => this.setInputValue('username',val)}
        />
      </div>
    );
  }
}

export default LoginForm;