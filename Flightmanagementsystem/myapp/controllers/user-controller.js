const User = require('../model/User');





const getUser =  (req, res, next) => {

    const user = new User({
        Id: res.body.Id,
        Username: res.body.Username,
        Email: res.body.Email,
        Password: res.body.Password,
        User_Role: res.body.User_Role,


    });
    try {
       
    } catch (err) {
        console.loq(err);
    }
    return res.status(201).json({ message: user })


}


exports.getUser = getUser;