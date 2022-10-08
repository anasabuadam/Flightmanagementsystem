const mongoose = require('mongoose');

const Schema = mongoose.Schema;

const customerSchema = new Schema({
    Id: {
        type: Array,
    },
    FirstName: {
        type: String,
        required: true
    },
    LastName: {
        type: String,
        required: true,
        minlength: 16,
    },
    Address: {
        type: String,
        required: true
    },
    PhoneNO: {
        type: String,
    },
    CreditCardNo: {
        type:String,
    },
    UserId: {
      type:  Array
    }
})

module.exports = mongoose.model('Customers', customerSchema);

