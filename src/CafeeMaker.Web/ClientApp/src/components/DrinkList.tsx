import React, {useState, useEffect} from "react";
import {Drink, getDrinks} from "../services/drinkService";
import {useHistory} from "react-router-dom";

export const DrinkList = () => {
    const [drinks, setDrinks] = useState<Drink[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const history = useHistory();

    useEffect(() => {
        (async () => {
            setDrinks(await getDrinks());
            setIsLoading(false);
        })();
    }, []);

    function onDrinkClick(id: number) {
        history.push(`/drink/${id}`);
    }

    return (
        <>
            <h1>Drinks</h1>
            <div className="row">
                {isLoading && <p>Loading</p>}
                {
                    drinks.map((drink) =>
                        <div className="col col-md-6" key={drink.drinkId}>
                            <div className="card mb-3">
                                <img src={drink.image} className="card-img-top" alt={drink.image}/>
                                <div className="card-body">
                                    <h5 className="card-title">{drink.name}</h5>
                                    <p className="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                                    <div className="text-right">
                                        <button className="btn btn-outline-primary btn-block"
                                                onClick={() => onDrinkClick(drink.drinkId)}>
                                            Choisir
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    )
                }
            </div>
        </>
    );
}