import React from "react";
import {DrinkList} from "./components/DrinkList";
import {BrowserRouter as Router, Switch, Route, useParams} from "react-router-dom";
import {Order} from "./components/Order";
import {Enjoy} from "./components/Enjoy";

export const App = () => {
    return (
        <div className="container">
            <Router>
                <Switch>
                    <Route exact path="/">
                        <DrinkList/>
                    </Route>
                    <Route path="/drink/:drinkId">
                        <Order/>
                    </Route>
                    <Route path="/enjoy">
                        <Enjoy/>
                    </Route>
                </Switch>
            </Router>
        </div>
    );
}