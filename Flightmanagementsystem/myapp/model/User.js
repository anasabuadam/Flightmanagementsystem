const mongoose = require('mongoose');

const Schema = mongoose.Schema;

const userSchema = new Schema({
    Id: {
        type: Array
    },
    Username: {
        type: String,
        required: true
    },
    Password: {
        type: String,
        required: true,

    },

    Email: {
        type: String,
        required: true,

    },
    User_Role: {
        type: Array,
    }
})

module.exports = mongoose.model('User', userSchema);

