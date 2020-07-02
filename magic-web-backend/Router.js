const bcrypt = require('bcrypt');
const WebSocket     = require('ws');


class Router {

    constructor(app){
        this.login(app);
        this.logout(app);
        this.isLoggedIn(app);
    }
    login(app){
        app.post('/login',(req,res) => {
            
            let username = req.body.username;
            let password = req.body.password;

            password = password.toUpperCase();

            console.log(username);
            console.log(password);

            
            var _socket = new WebSocket("ws://127.0.0.1:8181");

            _socket.onopen = function (event) {
                var obj = new Object();
                obj.username = username;
                obj.password = password;
                var jsonString = JSON.stringify(obj)
               _socket.send(jsonString); 
            };

            _socket.onmessage = function(event){
               console.log(event.data);
                if(event.data != '1'){
                        res.json({
                            success:false,
                            msg:'An error has occured, please try again'
                        })
                        _socket.close();
                    return;
                }
                else{
                    res.json({
                        success:true
                    })
                }

            }

            

            //add to the game

        });
    }
    logout(app){

    }
    isLoggedIn(app){

    }

}

module.exports = Router;