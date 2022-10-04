import React from 'react';



function LoginTap() {
    return (
        <div className="LoginTap">
            Hello You Can Login From this Page
            <div class="form-group">
                <label for="usr">Name:</label>
                <button variant="btn btn-success" onClick={() => History.push('/LoginUser')}>Click button to view products</button>

            </div>
            <div class="form-group">
                <label for="pwd">Password:</label>
                <input type="password" class="form-control" id="pwd"></input>
            </div>
        </div>
    );

}

export default LoginTap;


