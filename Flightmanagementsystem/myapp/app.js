
var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');
var app = express();
const { dboperations } = require('../myapp/dboperations');
const adminstratorsrouts = require('../myapp/routes/adminstrators-routs');
const router = express.Router();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(cors());
app.use('/api', router);


var port = process.env.port || 1433;
app.listen(port);
console.log("admin is runnig at " + port);


router.route("/admin",adminstratorsrouts).get((res => {

    dboperations.getAdmin().then(ress => {
        res.json(ress);
        console.log(ress);

    });
}))


