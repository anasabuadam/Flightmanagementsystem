const express = require('express');
const sql = require("mssql");
const app = express();

/*-------------------add details of sqlConfig-----------------*/

const config = {
    user: "sa",
    password: "duvoia1-rfas+dfc",
    server: "localhost",
    database: "master",
    options: {
        trustServerCertificate: true
    }
};

/******************************************************************/
app.get("/", async (req, res) => {
    try {
        await sql.connect(config);
        res.send("DB Connected");
    } catch (err) {
        res.send(err);
    }
});

const port = process.env.PORT || 5000;
app.listen(port, () => {
    console.log(`service is running on:: [${port}]`);
});