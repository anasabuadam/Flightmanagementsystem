var config = require('./dbconfig');
const sql = require('mssql');
const AdminStrators = require('./model/Adminstrators');

 async function getAdmin() {
    try {
        let pool = await sql.connect(config);
        let AdminStrators = await pool.request().query("SELECT * FROM Adminstrators");
        return AdminStrators.recordsets.findIndex;

    }
    catch (err) {
        console.log(err);
    }
}

async function getadminbyid(adminid) {
    try {
        let pool = await sql.connect(config);
        let admin = await pool.request()
            .input("input_parameter", sql.BigInt, adminid)
            .query("SELECT * FROM Adminstrators wehre Id = @input_parameter");
        return admin.recordsets;
    }
    catch (err) {
        console.log(err);

    }
}

module.exports = getAdmin;
