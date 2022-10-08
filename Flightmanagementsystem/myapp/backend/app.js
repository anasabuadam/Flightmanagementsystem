const express = require('express');
const sql = require("mssql");
const app = express();
const User = require('./model/User');
const getUser = require("./controllers/user-controller");
const config = require('./Server')

//Data Source=DESKTOP-LCKHR3P\MSSQLSERVER2019;Initial Catalog=FlightManagementSystem;Persist Security Info=True;User ID=anas;Password=***********/
app.get("/", function (req, res) {

    sql.connect(config, function (err) {

        if (err) console.log(err);

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records
        request.query('select * from User', function (err, recordset) {

            if (err) console.log(err)

            // send records as a response
            res.send(recordset);

            /******************************************************************/

        });
    });
});

var server = app.listen(5000, function () {
    console.log('Server is running..');
});
