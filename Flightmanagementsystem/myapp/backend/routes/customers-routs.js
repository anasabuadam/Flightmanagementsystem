﻿const express = require('express');
const Customers = require('../controllers/Customers-controller');
const { Router } = require('express');


const router = express.Router();

router.get("/Customers", Customers);

module.exports = router