const { get } = require('mongoose');
const Customers = require('../model/customers');





const addcustomers  =  (req, res, next) => {

    const customers = new Customers({
        Id: req.body.Id,
        f: req.body.Username,
        Email: req.body.Email,
        Password: req.body.Password,
        User_Role: req.body.User_Role,


    });
    try {
   
    } catch (err) {
        console.loq(err);
    }
    return res.status(201).json({ message: customers })


}


exports.addcustomers = addcustomers;