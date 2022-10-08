const express = require('express');
const { getUser } = require('../controllers/user-controller');


const { Router } = require('express');


const router = express.Router();


router.get("/User", getUser);

module.exports = router