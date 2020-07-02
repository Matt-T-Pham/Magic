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


new Router(app);

app.get('/',function(req,res){
    res.sendFile(path.join(__dirname,'build','index.html'));
});

app.listen(3000)