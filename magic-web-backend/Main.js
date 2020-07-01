const express       = require('express');
const app           = express();
const path          = require('path');
const mysql         = require('mysql');
const session       = require('express-session');
const MySQLStore    = require('express-mysql-session')(session);
const Router        = require('./Router');
const WebSocket     = require('ws');
const { KeyObject } = require('crypto');


app.use(express.static(path.join(__dirname,'build')));
app.use(express.json());

var exampleSocket = new WebSocket("ws://127.0.0.1:8181");

exampleSocket.onopen = function (event) {
    exampleSocket.send("Here's some text that the server is urgently awaiting!"); 
};

exampleSocket.onmessage = function(event){
    console.log(event.data);
}