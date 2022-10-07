const express = require('express');
const Adminstrators = require('../controllers/adminstrators-controller');
const { Router } = require('express');


const router = express.Router();

router.get("/Adminstrators", Adminstrators);

module.exports = router