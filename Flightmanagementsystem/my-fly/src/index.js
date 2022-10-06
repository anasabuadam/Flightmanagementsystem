import App from './comp/App';
import server from './comp/server'
import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, Link, browserHistory, IndexRoute } from 'react-router'

ReactDOM.render(
    <browserHistory>
        <Route>
            
            <switch>
                <Router>


     

                <server />
                <App />
                
                    <server />
                </Router>
            </switch>
            </Route>
        
        
        
    </browserHistory>
   ,
    document.getElementById("root"))





