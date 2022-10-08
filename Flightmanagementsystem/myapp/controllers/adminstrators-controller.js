const Adminstrators = require('../model/Adminstrators');





const AddAdmin = async (req, res, next) => {

    const adminstrators = new Adminstrators({
        Id: req.body.Id,
        First_Name: req.body.Username,
        Last_Name: req.body.Email,
        Level: req.body.Password,
        User_Id: req.body.User_Role,


    });
    try {
        await adminstrators.save();
    } catch (err) {
        console.loq(err);
    }
    return res.status(201).json({ message: adminstrators })


}


exports.AddAdmin = AddAdmin;