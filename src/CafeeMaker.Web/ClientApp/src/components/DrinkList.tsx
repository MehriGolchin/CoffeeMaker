import React, { useState, useEffect } from "react";
import {getDrinks} from "../services/drinkService";

export const Drink = () => {
    const [drinks, setDrinks] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    
    useEffect(() => {
        (async () => {
            await getDrinks();
        })();
    }, []);
    
     return (
         <>
         <h3>Drinks</h3>
              
         </>
     );
}