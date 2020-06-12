import React        from 'react';
import UserStore    from './Store/UserStore';
import LoginForm    from './LoginForm';
import InputField   from './InputField';
import SubmitButton from './SubmitButton';
import { observer } from 'mobx-react';
import './App.css';

class App extends React.Component{

  async componentDidMount(){

    try {
      let res = await fetch('/isLoggedIn',{
        method: 'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
      });

      let result = await res.json();
      
      if (result && result.success){
        UserStore.loading = false;
        UserStore.isLoggedIn = true;
        UserStore.userName = result.username;
      }
      else{
        UserStore.loading = false;
        UserStore.isLoggedIn = false;
      }
    }
    catch(e){
      console.log(e)
      UserStore.loading = false;
      UserStore.isLoggedIn = false;
    }
  }

  async doLogout(){
    try {
      let res = await fetch('/logout',{
        method: 'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
      });

      let result = await res.json();
      
      if (result && result.success){
        UserStore.userName = '';
        UserStore.isLoggedIn = false;
      }
    }
    catch(e){
        console.log(e)
    }
  }

  render(){
    if (UserStore.loading){
      return (
        <div className = "app">
          <div className='container'>               
            loading, please wait...
          </div>
        </div>
      );
    }
    else{
      if(UserStore.isLoggedIn){
        return (
          <div className = "app">
            <div className='container'>
              Welcome {UserStore.uyserName}
              <SubmitButton
                text = {'log out'}
                disabled = {false}
                onClick = { () => this.doLogout() }
              />
            </div>
          </div>
        );
      }
      return (
        <div className="app">
          <div className='container'>
            <LoginForm />
          </div>
        </div>
      );
    }
  }
}

export default observer(App);
