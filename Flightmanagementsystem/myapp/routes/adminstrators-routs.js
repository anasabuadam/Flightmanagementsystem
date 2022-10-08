const express = require('express');
const Adminstrators = require('../controllers/adminstrators-controller');
const { dboperations, getadminbyid, getAdmin } = require('../dboperations');
const { route } = require('./customers-routs');



const router = express.Router();

router.route("/").get((res) => {

    dboperations.getAdmin().then(ress => {
        ress.json(ress);
        console.log(ress);

    });
})

    module.exports = router;


