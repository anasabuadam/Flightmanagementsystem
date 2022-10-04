import React from 'react';
import ReactDom from 'react-dom';
import App from './comp/App';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import server from './comp/server'



ReactDom.render(
   <BrowserRouter>
        <Route>
            
            <Switch>
                <server />
                
                </Switch>
            </Route>
        
        
        
        </BrowserRouter>
   ,
    document.getElementById("root"))





