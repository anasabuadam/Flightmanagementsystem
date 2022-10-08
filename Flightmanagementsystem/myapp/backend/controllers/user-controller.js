const User = require('../model/User');





const getUser =  (req, res, next) => {

    const user = new User({
        Id: req.body.Id,
        Username: req.body.Username,
        Email: req.body.Email,
        Password: req.body.Password,
        User_Role: req.body.User_Role,


    });
    try {
       
    } catch (err) {
        console.loq(err);
    }
    return res.status(201).json({ message: user })


}


exports.getUser = getUser;