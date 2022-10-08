const mongoose = require('mongoose');

const Schema = mongoose.Schema;

const  adminstratorsSchema = new Schema({
    Id: {
        type: Array,
    },
    First_Name: {
        type: String,
        required: true
    },
    Last_Name: {
        type: String,
        required: true,
      
    },

    Level: {
        type: Array,
        required: true,
        unique: true,
    },
    User_Id: {
        type: Array,
    }
})

module.exports = mongoose.model('Adminstrators', adminstratorsSchema);

